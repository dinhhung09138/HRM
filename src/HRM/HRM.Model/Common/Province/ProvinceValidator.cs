using FluentValidation;

namespace HRM.Model.Common
{
    public abstract class ProvinceValidator : AbstractValidator<ProvinceModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(100);
        }

        public void Precedence()
        {
            RuleFor(m => m.Precedence).NotNull();
        }

        public void IsActive()
        {
            RuleFor(m => m.IsActive).NotNull();
        }
    }
}
