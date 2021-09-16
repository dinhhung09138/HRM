
namespace HRM.Model.HR
{
    public sealed class CreateEmployeeWorkingStatusModelValidator : EmployeeWorkingStatusValidator
    {
        public CreateEmployeeWorkingStatusModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
