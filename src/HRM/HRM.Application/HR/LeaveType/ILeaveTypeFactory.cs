using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface ILeaveTypeFactory
    {
        LeaveType Create(LeaveTypeModel model);

        LeaveType Update(LeaveTypeModel model);
    }
}
