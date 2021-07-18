namespace HRM.Model.Common
{
    public sealed class UpdateProvinceModelValidator : ProvinceValidator
    {
        public UpdateProvinceModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
