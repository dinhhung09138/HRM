
namespace HRM.Model.Common
{
    public sealed class CreateDistrictModelValidator : DistrictValidator
    {
        public CreateDistrictModelValidator()
        {
            Name();
            ProvinceId();
            Precedence();
            IsActive();
        }
    }
}
