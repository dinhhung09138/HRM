using System;

namespace HRM.Model.HR
{
    public class UpdateCustomerContactModelValidator : CustomerContactValidator
    {
        public UpdateCustomerContactModelValidator()
        {
            Id();
            Name();
            Phone();
            Email();
            Position();
            IsActive();
        }
    }
}
