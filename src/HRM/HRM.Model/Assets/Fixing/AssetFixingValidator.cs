using FluentValidation;

namespace HRM.Model.Assets
{
    public abstract class AssetFixingValidator : AbstractValidator<AssetFixingModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void AssetId()
        {
            RuleFor(m => m.AssetId).NotEmpty().NotNull();
        }

        public void FixingDate()
        {
            RuleFor(m => m.FixingDate).NotEmpty().NotNull();
        }

        public void VendorId()
        {
            RuleFor(m => m.VendorId).NotEmpty().NotNull();
        }

        public void Cost()
        {
            RuleFor(m => m.Cost).NotEmpty().NotNull();
        }

        public void Note()
        {
            RuleFor(m => m.Notes).MaximumLength(500);
        }

    }
}
