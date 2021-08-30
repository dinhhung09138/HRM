using System;

namespace HRM.Model.Assets
{
    public sealed class AssetLiquidationGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Vendor { get; set; }

        public DateTime? LiquidationDate { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalDivices { get; set; }
    }
}
