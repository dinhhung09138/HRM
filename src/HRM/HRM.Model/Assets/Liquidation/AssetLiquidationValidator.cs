using FluentValidation;

namespace HRM.Model.Assets
{
    public abstract class AssetLiquidationValidator : AbstractValidator<AssetLiquidationModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Code()
        {
            RuleFor(m => m.Code).NotEmpty().NotNull();
            RuleFor(m => m.Code).MaximumLength(20);
        }

        public void VendorId()
        {
            RuleFor(m => m.VendorId).NotEmpty().NotNull();
        }

        public void LiquidationDate()
        {
            RuleFor(m => m.LiquidationDate).NotEmpty().NotNull();
        }

        public void Notes()
        {
            RuleFor(m => m.Notes).MaximumLength(500);
        }

    }
}
