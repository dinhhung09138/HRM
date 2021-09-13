using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetHandoverInvoiceExpression
    {
        public static Expression<Func<AssetHandoverInvoice, AssetHandoverInvoiceModel>> FindByIdAsync => m => new AssetHandoverInvoiceModel()
        {
            Id = m.Id,
            Code = m.Code,
            HandoverBy = m.HandoverBy,
            HandoverDate = m.HandoverDate,
            ReceiveBy = m.ReceiveBy,
            ReceiveDate = m.ReceiveDate,
            Notes = m.Notes,
            Deleted = m.Deleted,
        };

        public static Expression<Func<AssetHandoverInvoice, AssetHandoverInvoiceGridModel>> GridAsync => m => new AssetHandoverInvoiceGridModel()
        {
            Id = m.Id,
            Code = m.Code,
            HandoverBy = m.Handover.FullName,
            HandoverDate = m.HandoverDate,
            ReceiveBy = m.Receiver.FullName,
            ReceiveDate = m.ReceiveDate,
        };
    }
}
