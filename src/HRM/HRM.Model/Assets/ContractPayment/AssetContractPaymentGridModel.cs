using System;

namespace HRM.Model.Assets
{
    public sealed class AssetContractPaymentGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public decimal Payment { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string Note { get; set; }
    }
}
