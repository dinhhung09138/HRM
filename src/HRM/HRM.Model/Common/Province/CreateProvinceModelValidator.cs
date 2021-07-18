
namespace HRM.Model.Common
{
    public sealed class CreateProvinceModelValidator : ProvinceValidator
    {
        public CreateProvinceModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
