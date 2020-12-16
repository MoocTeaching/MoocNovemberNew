using Mooc.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Models.Entities
{
    public class Student : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
