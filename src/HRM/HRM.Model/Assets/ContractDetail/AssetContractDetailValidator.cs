using FluentValidation;

namespace HRM.Model.Assets
{
    public class AssetContractDetailValidator : AbstractValidator<AssetContractDetailModel>
    {
        public void AssetContractId()
        {
            RuleFor(m => m.AssetContractId).NotEmpty().NotNull();
        }

        public void Price()
        {
            RuleFor(m => m.Price).NotEmpty().NotNull();
            RuleFor(m => m.Price).GreaterThan(100);
        }

        public void Quantity()
        {
            RuleFor(m => m.Quantity).NotEmpty().NotNull();
            RuleFor(m => m.Price).GreaterThan(0);
        }

        public void Vat()
        {
            RuleFor(m => m.Vat).GreaterThanOrEqualTo(0);
        }

        public void Notes()
        {
            RuleFor(m => m.Notes).MaximumLength(500);
        }
    }
}
