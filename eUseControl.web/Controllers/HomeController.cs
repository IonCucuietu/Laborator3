using eUseControl.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.web.Controllers
{
     public class HomeController : Controller
     {
          // GET: Home
          public ActionResult Index()
          {
               return View();
          }

          [UserMod]
          public ActionResult UserProfile()
          {
               return View("Profile");
          }
          public ActionResult Logout()
          {
               System.Web.HttpContext.Current.Session.Clear();
               if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("tsud"))
               {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["tsud"];
                    if (cookie != null)
                    {
                         cookie.Expires = DateTime.Now.AddDays(-1);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
               }

               return View();
          }

          [HttpPost]
          public ActionResult Index(string receiverEmail, string subject, string message)
          {
              
                         var senderemail = new MailAddress("lab61test@gmail.com", "Demo Test");
                         var receiveremail = new MailAddress(receiverEmail, "Receiver");

                         var password = "qpoasl123";
                         var sub = subject;
                         var body = message;

                         var smtp = new SmtpClient
                         {
                              Host = "smtp.gmail.com",
                              Port = 587,
                              EnableSsl = true,
                              DeliveryMethod = SmtpDeliveryMethod.Network,
                              UseDefaultCredentials = false,
                              Credentials = new NetworkCredential(senderemail.Address, password)
                         };

                         using (var mess = new MailMessage(senderemail, receiveremail)
                         {
                              Subject = subject,
                              Body = body
                         }
                         )
                         {
                              smtp.Send(mess);
                         }
                         return View();
                    }

              
          }
     }
