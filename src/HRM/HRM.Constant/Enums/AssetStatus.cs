using System;
using System.ComponentModel;

namespace HRM.Constant.Enums
{
    public enum AssetStatus
    {
        [Description("Tốt")]
        Good = 1,

        [Description("Đã bị hư hỏng")]
        Broken = 2,

        [Description("Đã thanh lý")]
        Liquidation = 3,
    }
}
