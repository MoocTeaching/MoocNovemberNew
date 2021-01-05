using Mooc.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Dtos.Teacher
{
    public class CreateOrUpdateTeacherDto : BaseEntityDto
    {


        public string ProfessorGuid { get; set; }

        [Required(ErrorMessage = "教师姓名必填")]
        [Display(Name = "教师姓名")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "级别必填")]
        [Display(Name = "级别")]
        public string Level { get; set; }


        [Required(ErrorMessage = "部门必填")]
        [Display(Name = "部门")]
        public string Department { get; set; }


        [Required(ErrorMessage = "工作单位必填")]
        [Display(Name = "工作单位")]
        public string Company { get; set; }

        [Display(Name = "简介")]
        public string Introduction { get; set; }

        public DateTime AddTime { get; set; }
    }
}
