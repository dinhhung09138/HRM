using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public long AssetTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        
        public long VendorId { get; set; }

        public decimal Cost { get; set; }

        public decimal FixingCost { get; set; }

        public decimal MantenanceCost { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType =typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? BuyingDate { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? WarrantyExpiryDate { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? LiquidationDate { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        public AssetStatus AssetStatus { get; set; }

        public bool IsAllowBorrow { get; set; } = false;
    }
}
