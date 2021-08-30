using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetContractExpression
    {
        public static Expression<Func<AssetContract, AssetContractModel>> FindByIdAsync => m => new AssetContractModel()
        {
            Id = m.Id,
            Code = m.Code,
            VendorId = m.VendorId,
            SignDate = m.SignDate,
            LiquidationDate = m.LiquidationDate,
            TotalCost = m.TotalCost,
            Payment = m.Payment,
            ResidualValue = m.ResidualValue,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            Details = m.AssetContractDetails.Select(dt => new AssetContractDetailModel()
            {
                AssetContractId = dt.AssetContractId,
                AssetId = dt.AssetId,
                Price = dt.Price,
                Quantity = dt.Quantity,
                Vat = dt.Vat,
                Total = dt.Total,
                Notes = dt.Notes
            }).ToList()
        };

        public static Expression<Func<AssetContract, AssetContractGridModel>> GridAsync => m => new AssetContractGridModel()
        {
            Id = m.Id,
            Code = m.Code,
            Vendor = m.Vendor.Name,
            SignDate = m.SignDate,
            LiquidationDate = m.LiquidationDate,
            TotalCost = m.TotalCost,
            Payment = m.Payment,
            ResidualValue = m.ResidualValue,
        };
    }
}
