using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class LeaveTypeExpression
    {
        public static Expression<Func<LeaveType, LeaveTypeModel>> FindByIdAsync => m => new LeaveTypeModel()
        {
            Id = m.Id,
            Code = m.Code,
            Name = m.Name,
            NumOfDay = m.NumOfDay,
            IsDeductible = m.IsDeductible,
            Description = m.Description,
            Precedence = m.Precedence,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<LeaveType, LeaveTypeGridModel>> GridAsync => m => new LeaveTypeGridModel()
        {
            Id = m.Id,
            Code = m.Code,
            Name = m.Name,
            NumOfDay = m.NumOfDay,
            IsDeductible = m.IsDeductible,
            Description = m.Description,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
