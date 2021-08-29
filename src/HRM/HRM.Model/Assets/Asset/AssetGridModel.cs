using System;

namespace HRM.Model.Assets
{
    public sealed class AssetGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public long AssetTypeName { get; set; }

        public string Status { get; set; }

        public DateTime? BuyingDate { get; set; }

        public DateTime? WarrantyExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
