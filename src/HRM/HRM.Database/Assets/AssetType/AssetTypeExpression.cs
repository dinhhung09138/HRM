using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Assets;
using HRM.Domain.Assets;
using System.Linq.Expressions;

namespace HRM.Database.Assets
{
    public static class AssetTypeExpression
    {
        public static Expression<Func<AssetType, AssetTypeModel>> FindByIdAsync => m => new AssetTypeModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Deleted = m.Deleted
        };

        public static Expression<Func<AssetType, AssetTypeGridModel>> GridAsync => m => new AssetTypeGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive
        };
    }
}
