using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetAssetLiquidationExpression
    {
        public static Expression<Func<AssetLiquidation, AssetLiquidationModel>> FindByIdAsync => m => new AssetLiquidationModel()
        {
            Id = m.Id,
            Code = m.Code,
            VendorId = m.VendorId,
            LiquidationDate = m.LiquidationDate,
            TotalCost = m.TotalCost,
            TotalDivices = m.TotalDivices,
            Notes = m.Notes,
            Deleted = m.Deleted,
        };

        public static Expression<Func<AssetLiquidation, AssetLiquidationGridModel>> GridAsync => m => new AssetLiquidationGridModel()
        {
            Id = m.Id,
            Code = m.Code,
            Vendor = m.Vendor.Name,
            LiquidationDate = m.LiquidationDate,
            TotalCost = m.TotalCost,
            TotalDivices = m.TotalDivices,
        };
    }
}
