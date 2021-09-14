using System;

namespace HRM.Model.HR
{
    public class UpdateEmployeeInfoModelValidator : EmployeeInfoValidator
    {
        public UpdateEmployeeInfoModelValidator()
        {
            Id();
            EmployeeId();
            IdCode();
            PassportCode();
            DriverLicenseCode();
        }
    }
}
