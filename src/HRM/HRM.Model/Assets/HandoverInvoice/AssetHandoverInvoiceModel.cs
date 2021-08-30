using HRM.Constant.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetHandoverInvoiceModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]

        public long HandoverBy { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? HandoverDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]

        public long ReceiveBy { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Date")]
        public DateTime? ReceiveDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public List<AssetHandoverInvoiceDetailModel> Details { get; set; } = new List<AssetHandoverInvoiceDetailModel>();
    }
}
