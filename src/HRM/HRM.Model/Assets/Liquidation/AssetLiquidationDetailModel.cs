using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetLiquidationDetailModel : BaseModel
    {
        public long AssetLiquidationId { get; set; }

        public long AssetId { get; set; }

        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
