using HRM.Constant.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Assets
{
    public sealed class AssetHandoverInvoiceDetailModel : BaseModel
    {
        public long HandoverInvoiceId { get; set; }

        public long AssetId { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }
    }
}
