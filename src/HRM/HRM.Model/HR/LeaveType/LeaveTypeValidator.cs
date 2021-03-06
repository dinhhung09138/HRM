using FluentValidation;

namespace HRM.Model.HR
{
    public class LeaveTypeValidator : AbstractValidator<LeaveTypeModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Code()
        {
            RuleFor(m => m.Code).NotEmpty().NotNull();
            RuleFor(m => m.Code).MaximumLength(10);
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(50);
        }

        public void NumOfDay()
        {
            RuleFor(m => m.NumOfDay).NotNull();
            RuleFor(m => m.NumOfDay).GreaterThan(0).WithMessage("not null");
        }

        public void Description()
        {
            RuleFor(m => m.Description).MaximumLength(255);
        }

        public void Precedence()
        {
            RuleFor(m => m.Precedence).NotEmpty().NotNull();
        }

    }
}
