namespace HRM.Model.HR
{
    public sealed class UpdateDepartmentModelValidator : DepartmentValidator
    {
        public UpdateDepartmentModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
