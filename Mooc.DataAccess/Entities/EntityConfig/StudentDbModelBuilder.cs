using Mooc.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.DataAccess.Entities.EntityConfig
{
    public static class StudentDbModelBuilder
    {
        public static void StudentModelBuilder(this DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<Student>().ToTable(nameof(Student));
            dbModelBuilder.Entity<Student>().Property(u => u.Name).IsRequired().HasMaxLength(100);
        }
    }
}
