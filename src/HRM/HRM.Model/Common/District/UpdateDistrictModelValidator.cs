namespace HRM.Model.Common
{
    public sealed class UpdateDistrictModelValidator : DistrictValidator
    {
        public UpdateDistrictModelValidator()
        {
            Id();
            Name();
            ProvinceId();
            Precedence();
            IsActive();
        }
    }
}
