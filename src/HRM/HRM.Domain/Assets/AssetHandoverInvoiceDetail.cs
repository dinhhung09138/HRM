using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.Assets
{
    public class AssetHandoverInvoiceDetail : Entity<long>
    {
        public AssetHandoverInvoiceDetail(
            long id,
            long handoverInvoiceId,
            long assetId,
            string notes)
        {
            Id = id;
            HandoverInvoiceId = handoverInvoiceId;
            AssetId = assetId;
            Notes = notes;
        }

        public long HandoverInvoiceId { get; set; }

        public AssetHandoverInvoice HandoverInvoice { get; set; }

        public long AssetId { get; set; }

        public Asset Asset { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
