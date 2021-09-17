using System;

namespace HRM.Model.HR
{
    public class UpdateLeaveTypeModelValidator : LeaveTypeValidator
    {
        public UpdateLeaveTypeModelValidator()
        {
            Id();
            Code();
            Name();
            NumOfDay();
            IsDeductible();
            Description();
            Precedence();
        }
    }
}
