using System;
using System.Data.Entity;
using eUseControl.Domain.Entities.User;



namespace eUseControl.BusinessLogic.DBModel
{


     public class UserContext : DbContext
     {
          public UserContext() :   base("name=eUseControl") //connectionstring name define in your web.config
          {
               /*Database.SetInitializer<UserContext>(null);*/
          }

          public virtual DbSet<SessionsDbTable> Sessions { get; set; }

          public virtual DbSet<UDbTable> Users { get; set; }
     }
}