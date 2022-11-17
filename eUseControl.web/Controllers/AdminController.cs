using eUseControl.App_Start;
using eUseControl.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.web.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin]
        [AdminMod]
        public ActionResult Index()
        {
               //SessionStatus();
               //if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               //{
               //     return RedirectToAction("Index", "Login");
               //}
            return View();
        }

     }
}