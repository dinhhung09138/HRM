using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetFixingModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]

        public long AssetId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime FixingDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]

        public long VendorId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public decimal Cost { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

    }
}
