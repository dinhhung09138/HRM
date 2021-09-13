using System;

namespace HRM.Model.HR
{
    public class UpdateEmployeeValidator : EmployeeValidator
    {
        public UpdateEmployeeValidator()
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
