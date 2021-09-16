using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class EmployeeWorkingStatusExpression
    {
        public static Expression<Func<EmployeeWorkingStatus, EmployeeWorkingStatusModel>> FindByIdAsync => m => new EmployeeWorkingStatusModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<EmployeeWorkingStatus, EmployeeWorkingStatusGridModel>> GridAsync => m => new EmployeeWorkingStatusGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive
        };
    }
}
