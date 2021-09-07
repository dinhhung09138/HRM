using System;

namespace HRM.Model.HR
{
    public class CreateCustomerModelValidator : CustomerValidator
    {
        public CreateCustomerModelValidator()
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
