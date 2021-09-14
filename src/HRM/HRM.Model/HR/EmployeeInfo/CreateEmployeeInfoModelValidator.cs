using System;

namespace HRM.Model.HR
{
    public class CreateEmployeeInfoModelValidator : EmployeeInfoValidator
    {
        public CreateEmployeeInfoModelValidator()
        {
            EmployeeId();
            IdCode();
            PassportCode();
            DriverLicenseCode();
        }
    }
}
