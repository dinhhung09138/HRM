
namespace HRM.Model.Assets
{
    public sealed class CreateAssetTypeModelValidator : AssetTypeValidator
    {
        public CreateAssetTypeModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
