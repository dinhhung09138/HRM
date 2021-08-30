using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetContractPaymentExpression
    {
        public static Expression<Func<AssetContractPayment, AssetContractPaymentModel>> FindByIdAsync => m => new AssetContractPaymentModel()
        {
            Id = m.Id,
            AssetContractId = m.AssetContractId,
            Payment = m.Payment,
            PaymentDate = m.PaymentDate,
            Notes = m.Notes,
            Deleted = m.Deleted,
        };

        public static Expression<Func<AssetContractPayment, AssetContractPaymentGridModel>> GridAsync => m => new AssetContractPaymentGridModel()
        {
            Id = m.Id,
            Code = m.AssetContract.Code,
            Payment = m.Payment,
            PaymentDate = m.PaymentDate,
            Notes = m.Notes,
        };
    }
}
