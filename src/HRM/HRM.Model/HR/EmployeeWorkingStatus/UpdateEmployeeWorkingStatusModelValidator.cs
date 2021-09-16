namespace HRM.Model.HR
{
    public sealed class UpdateEmployeeWorkingStatusModelValidator : EmployeeWorkingStatusValidator
    {
        public UpdateEmployeeWorkingStatusModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
