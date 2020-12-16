using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.DataAccess.Enums
{
   public enum RoleTypeEnum
    {
        管理员 = 1,
        老师 = 2,
        学生 = 3
    }
    public enum StatusEnum
    {
        正常 = 0,
        锁定 = 1
    }

    public enum GenderEnum
    {
        不男不女 = 0,
        男 = 1,
        女 = 2
    }

}
