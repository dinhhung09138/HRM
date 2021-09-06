using System;

namespace HRM.Model.Assets
{
    public sealed class CreateAssetContractDetailModelValidator : AssetContractDetailValidator
    {
        public CreateAssetContractDetailModelValidator()
        {
            AssetContractId();
            Quantity();
            Price();
            Vat();
            Notes();
        }
    }
}
