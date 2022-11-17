using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.web.Models;

namespace eUseControl.web.Controllers
{
     public class LoginController : Controller
     {
          private readonly ISession _session;
          public LoginController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }

          // GET: Login
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    ULoginData data = new ULoginData
                    {
                         Credential = login.Credential,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now,
                         Role = login.LoginRole
                    };

                    UDbTable result;
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == data.Password);
                    }

                    data.Role = result.Level;

                    string appPath = Request.PhysicalApplicationPath;
                    string filePath = appPath + "Text.txt";
                    StreamWriter w;
                    w = System.IO.File.CreateText(filePath);
                    //w.WriteLine(data.Credential);
                    w.WriteLine(data.Role);
                    w.Close();

                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         //ADD COOKIE

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }

               }

               return View();
          }
     }
}


