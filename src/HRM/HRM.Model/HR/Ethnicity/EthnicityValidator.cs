using FluentValidation;

namespace HRM.Model.HR
{
    public class EthnicityValidator : AbstractValidator<EthnicityModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(50);
        }

    }
}
