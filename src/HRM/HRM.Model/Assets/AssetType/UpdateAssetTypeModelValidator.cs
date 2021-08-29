namespace HRM.Model.Assets
{
    public sealed class UpdateAssetTypeModelValidator : AssetTypeValidator
    {
        public UpdateAssetTypeModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
