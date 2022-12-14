using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
     public class SessionsDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string UserEmail { get; set; }
          [Required]
          public string CookieString { get; set; }
          [Required]
          public URole Level { get; set; }

          [Required]
          public DateTime ExpireTime { get; set; }

          public string Role { get; set; }
     }
}
