using System;

namespace HRM.Model.HR
{
    public class UpdateEmployeeInfoValidator : EmployeeInfoValidator
    {
        public UpdateEmployeeInfoValidator()
        {
            Id();
            EmployeeId();
            IdCode();
            PassportCode();
            DriverLicenseCode();
        }
    }
}
