using System;
using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public class AssetTypeFactory : IAssetTypeFactory
    {
        public AssetType Create(AssetTypeModel model)
        {
            var item = new AssetType(model.Id, model.Name, model.IsActive, model.CreateBy, DateTime.Now, null, null);
            return item;
        }

        public AssetType Update(AssetTypeModel model)
        {
            var item = new AssetType(model.Id, model.Name, model.IsActive, model.CreateBy, DateTime.Now, model.UpdateBy, DateTime.Now);
            return item;
        }
    }
}
