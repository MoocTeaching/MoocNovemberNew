using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mooc.Shared.Enums
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