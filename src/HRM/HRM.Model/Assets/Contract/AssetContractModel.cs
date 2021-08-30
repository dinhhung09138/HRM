using HRM.Constant.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetContractModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]

        public long VendorId { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? SignDate { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? LiquidationDate { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Payment { get; set; }

        public decimal ResidualValue { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }


        public List<AssetContractDetailModel> Details { get; set; } = new List<AssetContractDetailModel>();
    }
}
