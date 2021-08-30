using FluentValidation;

namespace HRM.Model.Assets
{
    public abstract class AssetContractPaymentValidator : AbstractValidator<AssetContractPaymentModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void AssetContractId()
        {
            RuleFor(m => m.AssetContractId).NotEmpty().NotNull();
        }

        public void Payment()
        {
            RuleFor(m => m.Payment).NotEmpty().NotNull();
        }

        public void PaymentDate()
        {
            RuleFor(m => m.PaymentDate).NotEmpty().NotNull();
        }

        public void Notes()
        {
            RuleFor(m => m.Notes).MaximumLength(500);
        }

    }
}
