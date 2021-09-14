using System;

namespace HRM.Model.HR
{
    public class UpdateEmployeeModelValidator : EmployeeValidator
    {
        public UpdateEmployeeModelValidator()
        {
            Id();
            EmployeeCode();
            FullName();
            BranchId();
            Email();
            Phone();
            PhoneExt();
            Fax();
            BadgeCardNumber();
            FingerSignNumber();
        }
    }
}
