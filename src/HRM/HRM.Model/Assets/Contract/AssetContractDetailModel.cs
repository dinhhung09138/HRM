using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetContractDetailModel : BaseModel
    {
        public long AssetContractId { get; set; }

        public long AssetId { get; set; }

        public decimal Price { get; set; }

        public float Quantity { get; set; }

        public float Vat { get; set; }

        public decimal Total { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }
    }
}
