using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers.Session;

namespace eUseControl.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          private readonly UserApi userApi = new UserApi();

          public string GenCookieByUser(ULoginData data)
          {
               throw new NotImplementedException();
          }

          public ULoginResp UserLogin(ULoginData data)
          {
               return userApi.UserLoginAction(data);
          }

          public ULoginResp UserRegister(URegisterData data)
          {
               return userApi.UserRegisterAction(data);
          }

          public SessionsDbTable GetUserByCookie(string data)
          {
              return userApi.UserMinimalAction(data);
          }
     }
}