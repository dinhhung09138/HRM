using HRM.Constant.Enums;
using System;

namespace HRM.Model.Assets
{
    public sealed class AssetGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string AssetTypeName { get; set; }

        public AssetStatus Status { get; set; }

        public DateTime? BuyingDate { get; set; }

        public DateTime? WarrantyExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
