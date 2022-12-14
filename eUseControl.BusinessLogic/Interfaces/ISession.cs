using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
          ULoginResp UserRegister(URegisterData data);
          string GenCookieByUser(ULoginData data);
          SessionsDbTable GetUserByCookie(string apiCookieValue);
     }
}
