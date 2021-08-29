using System;

namespace HRM.Model.Assets
{
    public sealed class AssetFixingGridModel
    {
        public long Id { get; set; }

        public string AssetName { get; set; }

        public string VendorName { get; set; }

        public long AssetFixingTypeName { get; set; }

        public DateTime FixingDate { get; set; }

        public decimal Cost { get; set; }
    }
}
