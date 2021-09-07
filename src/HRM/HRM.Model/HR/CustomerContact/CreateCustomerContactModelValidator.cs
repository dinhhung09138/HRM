using System;

namespace HRM.Model.HR
{
    public class CreateCustomerContactModelValidator : CustomerContactValidator
    {
        public CreateCustomerContactModelValidator()
        {
            Name();
            Phone();
            Email();
            Position();
            IsActive();
        }
    }
}
