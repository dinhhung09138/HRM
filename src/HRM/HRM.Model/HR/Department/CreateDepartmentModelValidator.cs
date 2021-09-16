
namespace HRM.Model.HR
{
    public sealed class CreateDepartmentModelValidator : DepartmentValidator
    {
        public CreateDepartmentModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
