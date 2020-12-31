using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Dtos.Base
{
    public class PageResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }//每页有多少数据
        public int Count { get; set; }
        public int PageCount => (int)Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(PageSize));
        public List<T> data { get; set; }
    }
}
