using Mooc.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.DataAccess.Entities.EntityConfig
{
  public static  class UserDbModelBuilder
    {
        public static void UserModelBuilder(this DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<User>().ToTable(nameof(User));
            dbModelBuilder.Entity<User>().Property(u => u.UserName).IsRequired().HasMaxLength(100);
            dbModelBuilder.Entity<User>().Property(u => u.PassWord).IsRequired().HasMaxLength(100);
            dbModelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100);
        }
    }
}
