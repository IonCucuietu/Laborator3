using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using System.Web.Routing;
using eUseControl.Domain.Enums;
using eUseControl.Web.Extension;

namespace eUseControl.App_Start
{
     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
     public class NoDirectAccessCustomAccesFilter : ActionFilterAttribute
     {
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               if (filterContext.HttpContext.Request.Url != null &&
               (filterContext.HttpContext.Request.UrlReferrer == null ||
               filterContext.HttpContext.Request.Url.Host !=
               filterContext.HttpContext.Request.UrlReferrer.Host))
               {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                         controller = "Error",
                         action =
                    "Error500"
                    }));
               }
          }
     }
     public class AdminModAttribute : ActionFilterAttribute
     {
          public string Role;

          private readonly ISession _session;
          public AdminModAttribute()
          {
               string appPath = @"C:/Users/ioncu/source/repos/eUseControl.web/eUseControl.web/";
               string filePath = appPath + "Text.txt";
               Role = System.IO.File.ReadAllText(filePath);
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               
               var adminSession = HttpContext.Current.GetMySessionObject();
               if (adminSession == null)
               {
                    var cookie = HttpContext.Current.Request.Cookies["tsud"];
                    if (cookie == null)
                    {
                        
                         var profile = _session.GetUserByCookie("tsud");
                         profile.Role = Role.Trim();
                         if (profile != null && profile.Role == "Admin")
                         {
                              
                              Console.Write(profile.Level);
                              HttpContext.Current.SetMySessionObject(profile);

                         }
                         else
                         {
                              filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary(new
                              {
                                   controller = "Error",
                                   action = "Error404"
                              }));
                         }
                    }
                    else
                    {

                         //if (adminSession.Level != URole.Admin)
                         //{
                         filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary(new
                         {
                              controller = "Error",
                              action = "Error404"
                         }));
                         //}
                    }
               }
          }
     }
     public class UserModAttribute : ActionFilterAttribute
     {
          private readonly ISession _session;
          public UserModAttribute()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var adminSession = HttpContext.Current.GetMySessionObject();
               if (adminSession == null)
               {
                    var cookie = HttpContext.Current.Request.Cookies["tsud"];
                    if (cookie != null)
                    {
                         var profile = _session.GetUserByCookie(cookie.Value);
                         if (profile != null && profile.Level == URole.Subscriber)
                         {
                              HttpContext.Current.SetMySessionObject(profile);
                         }
                         else
                         {
                              filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary(new
                              {
                                   controller = "Error",
                                   action =
                              "Error404"
                              }));
                         }
                    }
                    else
                    {
                         //if (adminSession.Level != URole.Subscriber)
                         //{
                         filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary(new
                         {
                              controller = "Error",
                              action =
                         "Error404"
                         }));
                         //}
                    }
               }
          }
     }
}