using eUseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.web.Models
{
     public class UserLogin
     {
          public string Credential { get; set; }
          public string Password { get; set; }

          public URole LoginRole { get; set; }
     }
}