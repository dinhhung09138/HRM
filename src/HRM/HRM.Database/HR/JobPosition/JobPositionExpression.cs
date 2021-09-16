using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class JobPositionExpression
    {
        public static Expression<Func<JobPosition, JobPositionModel>> FindByIdAsync => m => new JobPositionModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<JobPosition, JobPositionGridModel>> GridAsync => m => new JobPositionGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive
        };
    }
}
