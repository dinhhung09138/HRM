using FluentValidation;

namespace HRM.Model.HR
{
    public class NationalityValidator : AbstractValidator<NationalityModel>
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
