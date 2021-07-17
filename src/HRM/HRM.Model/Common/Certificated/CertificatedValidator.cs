using FluentValidation;

namespace HRM.Model.Common
{
    public abstract class CertificatedValidator : AbstractValidator<CertificatedModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(150);
        }
    }
}
