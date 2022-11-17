using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities.User;

namespace eUseControl.Web.Extension
{
     public static class HttpContextExtensions
     {
          public static SessionsDbTable GetMySessionObject(this HttpContext current)
          {
               return (SessionsDbTable)current?.Session["__SessionObject"];
          }

          public static void SetMySessionObject(this HttpContext current, SessionsDbTable profile)
          {
               current.Session.Add("__SessionObject", profile);
          }
     }
}