using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class LeaveTypeFactory : ILeaveTypeFactory
    {
        public LeaveType Create(LeaveTypeModel model)
        {
            var item = new LeaveType(model.Id,
                model.Code,
                model.Name,
                model.NumOfDay,
                model.IsDeductible,
                model.Description,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public LeaveType Update(LeaveTypeModel model)
        {
            var item = new LeaveType(model.Id,
                model.Code,
                model.Name,
                model.NumOfDay,
                model.IsDeductible,
                model.Description,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                model.UpdateBy,
                DateTime.Now);
            return item;
        }
    }
}
