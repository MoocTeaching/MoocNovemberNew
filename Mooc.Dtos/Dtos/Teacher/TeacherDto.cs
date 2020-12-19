using Mooc.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Dtos.Teacher
{
    public class TeacherDto : BaseEntityDto
    {
        public long ProfessorId { get; set; }

        [Display(Name = "教师姓名")]
        public string TeacherName { get; set; }

        [Display(Name = "级别")]
        public string Level { get; set; }


        [Display(Name = "部门")]
        public string Department { get; set; }


        [Display(Name = "工作单位")]
        public string Company { get; set; }

        [Display(Name = "简介")]
        public string Introduction { get; set; }

        [Display(Name = "加入时间")]
        public DateTime AddTime { get; set; }
    }
}
