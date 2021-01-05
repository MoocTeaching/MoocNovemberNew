using Mooc.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mooc.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string Email { get; set; }

        public int UserState { get; set; }

        public int RoleType { get; set; }

        public DateTime? AddTime { get; set; }

        public string Gender { get; set; }

        public string StudentNo { get; set; }

        public string Faulty { get; set; }

        public string Major { get; set; }

        public int CountryId { get; set; }

        public string ProfessorGuid { get; set; }

        public long ProfessorId { get; set; }

        public string PhotoFileName { get; set; }

        public string NickName { get; set; }

        public string Teacher { get; set; }

    }
}