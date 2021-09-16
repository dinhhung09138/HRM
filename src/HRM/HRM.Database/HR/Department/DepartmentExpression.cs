using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class DepartmentExpression
    {
        public static Expression<Func<Department, DepartmentModel>> FindByIdAsync => m => new DepartmentModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Department, DepartmentGridModel>> GridAsync => m => new DepartmentGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive
        };
    }
}
