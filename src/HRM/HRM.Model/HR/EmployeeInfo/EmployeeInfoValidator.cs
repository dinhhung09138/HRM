using FluentValidation;

namespace HRM.Model.HR
{
    public class EmployeeInfoValidator : AbstractValidator<EmployeeInfoModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void EmployeeId()
        {
            RuleFor(m => m.EmployeeId).NotEmpty().NotNull();
        }

        public void IdCode()
        {
            RuleFor(m => m.IdCode).MaximumLength(20);
        }

        public void PassportCode()
        {
            RuleFor(m => m.PassportCode).MaximumLength(20);
        }

        public void DriverLicenseCode()
        {
            RuleFor(m => m.DriverLicenseCode).MaximumLength(20);
        }

    }
}
