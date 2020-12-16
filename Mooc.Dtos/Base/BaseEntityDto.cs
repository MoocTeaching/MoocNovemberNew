using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Dtos.Base
{
    public abstract class BaseEntityDto<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntityDto : BaseEntityDto<int>
    {

    }
}
