using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TeamsMVC.Enums
{
    public enum Conference
    {
        [Description("Запад")]
        West = 1,

        [Description("Восток")]
        East = 2
    }
}