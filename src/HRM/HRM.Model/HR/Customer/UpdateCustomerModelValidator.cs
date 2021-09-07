using System;

namespace HRM.Model.HR
{
    public class UpdateCustomerModelValidator : CustomerValidator
    {
        public UpdateCustomerModelValidator()
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
