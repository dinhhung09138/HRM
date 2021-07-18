
namespace HRM.Model.Common
{
    public sealed class CreateWardModelValidator : WardValidator
    {
        public CreateWardModelValidator()
        {
            Name();
            DistrictId();
            Precedence();
            IsActive();
        }
    }
}
