using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetLiquidationDetailModel : BaseModel
    {
        public long ContractLiquidationId { get; set; }

        public long AssetId { get; set; }

        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }
    }
}
