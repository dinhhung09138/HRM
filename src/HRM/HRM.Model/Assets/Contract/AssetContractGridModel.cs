using System;

namespace HRM.Model.Assets
{
    public sealed class AssetContractGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Vendor { get; set; }

        public DateTime? SignDate { get; set; }

        public DateTime? LiquidationDate { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Payment { get; set; }

        public decimal ResidualValue { get; set; }

        public string Notes { get; set; }
    }
}
