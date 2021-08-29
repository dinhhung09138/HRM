
namespace HRM.Model.Assets
{
    public sealed class CreateAssetContractModelValidator : AssetContractValidator
    {
        public CreateAssetContractModelValidator()
        {
            Code();
            VendorId();
            SignDate();
            Note();
        }
    }
}
