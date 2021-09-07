using System;

namespace HRM.Model.HR
{
    public class CreateVendorModelValidator : VendorValidator
    {
        public CreateVendorModelValidator()
        {
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
