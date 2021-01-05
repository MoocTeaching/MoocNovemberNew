using Mooc.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Models.Entities
{
    public class Teacher : BaseEntity
    {
        public string ProfessorGuid { get; set; }

        public string TeacherName { get; set; }

        public string Level { get; set; }

        public string Department { get; set; }

        public string Company{ get; set; }

        public string Introduction { get; set; }

        public DateTime AddTime { get; set; }

    }
}
