using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;

namespace eUseControl.BusinessLogic.Core
{
     public class UserApi
     {
          internal ULoginResp UserLoginAction(ULoginData data)
          {
               UDbTable result;
               using (var db = new UserContext())
               {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password
                    == data.Password);
               }
               if (result == null)
               {
                    return new ULoginResp
                    {
                         Status = false,
                         StatusMsg = "The username or password is incorrect"
                    };
               }
               return new ULoginResp { Status = true };
          }
          internal ULoginResp UserRegisterAction(URegisterData data)
          {
               UDbTable result;
               var user = new UDbTable();
               user.Email = data.Email;
               user.Username = data.Username;
               user.Password = data.Password;
               //user.RegisterDate = data.RegisterDateTime;
               user.Level = URole.Guest;
               try
               {
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Username);
                         if (result == null)
                         {
                              db.Users.Add(user);
                              db.SaveChanges();
                              return new ULoginResp { Status = true };
                         }
                         else
                         {
                              return new ULoginResp
                              {
                                   Status = false,
                                   StatusMsg = "Invalid Username."
                              };
                         }
                    }
               }
               catch (DbEntityValidationException)
               {
                    throw;
               }
          }

          internal SessionsDbTable UserMinimalAction(string some)
          {
               SessionsDbTable minim = new SessionsDbTable
               {
                    UserEmail = "Test",
                    CookieString = "test@mail.ru"

               };

               return minim;
          }

          internal HttpCookie Cookie(string loginCredential)
          {
               var apiCookie = new HttpCookie("tsud")
               {
                    Value = CookieGenerator.Create(loginCredential)
               };
               using (var db = new UserContext())
               {
                    SessionsDbTable curent;
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(loginCredential))
                    {
                         curent = (from e in db.Sessions
                                   where e.UserEmail == loginCredential
                                   select e).FirstOrDefault();
                    }
                    else
                    {
                         curent = (from e in db.Sessions
                                   where e.UserEmail == loginCredential
                                   select e).FirstOrDefault();
                    }
                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(60);
                         using (var up = new UserContext())
                         {
                              up.Entry(curent).State = EntityState.Modified;
                              up.SaveChanges();
                         }
                    }
                    else
                    {
                         db.Sessions.Add(new SessionsDbTable
                         {
                              UserEmail = loginCredential,
                              CookieString = apiCookie.Value,
                              ExpireTime = DateTime.Now.AddMinutes(60)
                         });
                         db.SaveChanges();
                    }
               }
               return apiCookie;
          }
     }
}