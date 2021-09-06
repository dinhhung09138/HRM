using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetContractDetailModel : BaseModel
    {
        public string RowId { get; set; } = Guid.NewGuid().ToString();

        public long AssetContractId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public long? AssetTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string AssetTypeIdValue { get; set; }

        [Range(100, double.MaxValue, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public float Quantity { get; set; } = 1;

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public float Vat { get; set; }

        public decimal Total
        {
            get
            {
                return Price * (decimal)Quantity + (Price * ((decimal)Vat / 100));
            }
            set
            {
                Total = value;
            }
        }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
