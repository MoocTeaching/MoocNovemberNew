using Mooc.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.DataAccess.Entities.EntityConfig
{
    public static class TeacherDbModelBuilder
    {
        public static void TeacherModelBuilder(this DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<Teacher>().ToTable(nameof(Teacher));
            dbModelBuilder.Entity<Teacher>().Property(u => u.TeacherName).IsRequired().HasMaxLength(100);
            dbModelBuilder.Entity<Teacher>().Property(u => u.Level).IsRequired();
            dbModelBuilder.Entity<Teacher>().Property(u => u.Department).IsRequired().HasMaxLength(100);
            dbModelBuilder.Entity<Teacher>().Property(u => u.Company).IsRequired().HasMaxLength(100);
        }
    }
}
