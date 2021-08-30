using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetFixingExpression
    {
        public static Expression<Func<AssetFixing, AssetFixingModel>> FindByIdAsync => m => new AssetFixingModel()
        {
            Id = m.Id,
            AssetId = m.AssetId,
            FixingDate = m.FixingDate,
            VendorId = m.VendorId,
            Cost = m.Cost,
            Notes = m.Notes,
            Deleted = m.Deleted,
        };

        public static Expression<Func<AssetFixing, AssetFixingGridModel>> GridAsync => m => new AssetFixingGridModel()
        {
            Id = m.Id,
            AssetName = m.Asset.Name,
            VendorName = m.Vendor.Name,
            FixingDate = m.FixingDate,
            Cost = m.Cost,
        };
    }
}
