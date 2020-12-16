using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Models.Entities.Base
{
    public abstract class BaseEntity<TKey> where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
