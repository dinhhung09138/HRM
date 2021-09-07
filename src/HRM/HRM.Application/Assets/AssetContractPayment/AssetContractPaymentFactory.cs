using System;
using HRM.Domain.Assets;
using HRM.Model.Assets;

namespace HRM.Application.Assets
{
    public class AssetContractPaymentFactory : IAssetContractPaymentFactory
    {
        public AssetContractPayment Create(AssetContractPaymentModel model)
        {
            var item = new AssetContractPayment(
                model.Id, 
                model.AssetContractId, 
                model.Payment,
                model.PaymentDate,
                model.Notes,
                model.CreateBy, 
                DateTime.Now, 
                null, 
                null);
            return item;
        }

        public AssetContractPayment Update(AssetContractPaymentModel model)
        {
            var item = new AssetContractPayment(
                model.Id,
                model.AssetContractId,
                model.Payment,
                model.PaymentDate,
                model.Notes,
                model.CreateBy, 
                DateTime.Now, 
                model.UpdateBy, 
                DateTime.Now);
            return item;
        }
    }
}
