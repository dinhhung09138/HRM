using FluentValidation;

namespace HRM.Model.Assets
{
    public abstract class AssetContractValidator : AbstractValidator<AssetContractModel>
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

        public void SignDate()
        {
            RuleFor(m => m.SignDate).NotEmpty().NotNull();
        }

        public void Note()
        {
            RuleFor(m => m.Note).MaximumLength(500);
        }

    }
}
