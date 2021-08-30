using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetContractDetailModel : BaseModel
    {
        public long AssetContractId { get; set; }

        public long AssetId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float Vat { get; set; }

        public decimal Total { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
