using System;
using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public class AssetContractDetailFactory : IAssetContractDetailFactory
    {
        public AssetContractDetail Create(AssetContractDetailModel model)
        {
            var item = new AssetContractDetail(
                model.Id, 
                model.AssetContractId, 
                model.AssetTypeId.Value, 
                model.Price, 
                model.Quantity,
                model.Vat, 
                model.Total, 
                model.Notes);
            return item;
        }
    }
}
