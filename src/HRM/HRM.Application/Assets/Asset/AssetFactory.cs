using System;
using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public class AssetFactory : IAssetFactory
    {
        public Asset Create(AssetModel model)
        {
            var item = new Asset(model.Id, 
                model.Code,
                string.Empty,
                model.SerialNumber,
                model.AssetTypeId.Value,
                model.VendorId.Value,
                model.Cost,
                model.FixingCost,
                model.MantenanceCost,
                model.BuyingDate,
                model.WarrantyExpiryDate,
                model.LiquidationDate,
                model.Notes,
                model.AssetStatus,
                model.IsAllowBorrow,
                model.IsActive, 
                model.CreateBy, 
                DateTime.Now, 
                null, null);
            return item;
        }

        public Asset Update(AssetModel model)
        {
            var item = new Asset(model.Id,
                model.Code,
                string.Empty,
                model.SerialNumber,
                model.AssetTypeId.Value,
                model.VendorId.Value,
                model.Cost,
                model.FixingCost,
                model.MantenanceCost,
                model.BuyingDate,
                model.WarrantyExpiryDate,
                model.LiquidationDate,
                model.Notes,
                model.AssetStatus,
                model.IsAllowBorrow,
                model.IsActive,
                model.CreateBy, 
                DateTime.Now, 
                model.UpdateBy, 
                DateTime.Now);
            return item;
        }
    }
}
