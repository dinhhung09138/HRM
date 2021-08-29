using System;

namespace HRM.Model.Assets
{
    public sealed class AssetHandoverInvoiceGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string HandoverBy { get; set; }

        public DateTime? HandoverDate { get; set; }

        public string ReceiveBy { get; set; }

        public DateTime? ReceiveDate { get; set; }
    }
}
