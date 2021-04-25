using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TeamsMVC.Enums
{
    /// <summary>
    /// Позиции игроков
    /// </summary>
    public enum Position
    {
        [Description("Разыгрывающий защитник")]
        PG = 1,

        [Description("Атакующий защитник")]
        SG = 2,

        [Description("Легкий форвард")]
        SF = 3,

        [Description("Тяжелый форвард")]
        PF = 4,

        [Description("Центровой")]
        C = 5
    }
}