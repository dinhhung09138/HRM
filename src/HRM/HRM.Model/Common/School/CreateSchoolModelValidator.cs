
namespace HRM.Model.Common
{
    public sealed class CreateSchoolModelValidator : SchoolValidator
    {
        public CreateSchoolModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
