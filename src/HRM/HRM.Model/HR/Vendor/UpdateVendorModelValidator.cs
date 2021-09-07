using System;
namespace HRM.Model.HR
{
    public class UpdateVendorModelValidator : VendorValidator
    {
        public UpdateVendorModelValidator()
        {
            Id();
            Name();
            Phone();
            Email();
            Address();
            TaxCode();
            Notes();
            IsActive();
        }
    }
}
