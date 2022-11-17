using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
namespace eUseControl.Web.Controllers
{
     public class RegisterController : Controller
     {
          // GET: Register
          public ActionResult Index()
          {
               return View();
          }
          private readonly ISession _session;
          public RegisterController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }
          [HttpPost]
          public ActionResult Index(UserRegister data)
          {
               if (ModelState.IsValid)
               {
                    URegisterData login = new URegisterData
                    {
                         Email = data.Email,
                         Username = data.Username,
                         Password = data.Password,
                         RegisterDateTime = DateTime.Now
                    };
                    var userRegistration = _session.UserRegister(login);
                    if (userRegistration.Status)
                    {
                         ViewBag.Name = "Successful registration!";
                    }
                    else
                    {
                         ModelState.AddModelError("", userRegistration.StatusMsg);
                         return View();
                    }
               }
               return View();
          }
     }
}