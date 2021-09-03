using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetExpression
    {
        public static Expression<Func<Asset, AssetModel>> FindByIdAsync => m => new AssetModel()
        {
            Id = m.Id,
            Code = m.Code,
            Name = m.Name,
            SerialNumber = m.SerialNumber,
            AssetTypeId = m.AssetTypeId,
            VendorId = m.VendorId,
            Cost = m.Cost,
            FixingCost = m.FixingCost,
            MantenanceCost = m.MantenanceCost,
            BuyingDate = m.BuyingDate,
            WarrantyExpiryDate = m.WarrantyExpiryDate,
            LiquidationDate = m.LiquidationDate,
            Notes = m.Notes,
            AssetStatus = m.AssetStatus,
            IsAllowBorrow = m.IsAllowBorrow,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Asset, AssetGridModel>> GridAsync => m => new AssetGridModel()
        {
            Id = m.Id,
            Code = m.Code,
            Name = m.Name,
            AssetTypeName = m.AssetType.Name,
            Status = m.AssetStatus,
            BuyingDate = m.BuyingDate,
            WarrantyExpiryDate = m.WarrantyExpiryDate,
            IsActive = m.IsActive
        };
    }
}
