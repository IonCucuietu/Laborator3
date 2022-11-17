using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
     public class UserRegister
     {
          // [Required(ErrorMessage ="The file name field is empty")]
          [Display(Name = "Username")]
          // [StringLength(30, MinimumLength = 4, ErrorMessage = "Name must be more than 4 characters and less than 30")]
          public string Username { get; set; }

          [Display(Name = "Email Address")]
          // [StringLength(30, MinimumLength = 4, ErrorMessage = "Email must be less than 30")]
          public string Email { get; set; }

          // [StringLength(30, MinimumLength = 4, ErrorMessage = "Password must be more than 4 characters and less than 30")]
          public string Password { get; set; }

          // public bool Status { get; set; }
     }
}