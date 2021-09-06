using System;

namespace HRM.Model.Assets
{
    public sealed class CreateAssetContractDetailModelValidator : AssetContractDetailValidator
    {
        public CreateAssetContractDetailModelValidator()
        {
            Quantity();
            Price();
            Vat();
            Notes();
        }
    }
}
