using System;
using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public class AssetContractFactory : IAssetContractFactory
    {
        public AssetContract Create(AssetContractModel model)
        {
            var item = new AssetContract(
                model.Id,
                model.Code,
                model.VendorId.Value, 
                model.SignDate,
                model.LiquidationDate,
                model.TotalCost,
                model.Payment,
                model.ResidualValue,
                model.Notes,
                model.IsActive, 
                model.CreateBy, 
                DateTime.Now, 
                null, 
                null);
            return item;
        }

        public AssetContract Update(AssetContractModel model)
        {
            var item = new AssetContract(
                model.Id,
                model.Code,
                model.VendorId.Value,
                model.SignDate,
                model.LiquidationDate,
                model.TotalCost,
                model.Payment,
                model.ResidualValue,
                model.Notes,
                model.IsActive, 
                model.CreateBy, 
                DateTime.Now, 
                model.UpdateBy, 
                DateTime.Now);
            return item;
        }
    }
}
