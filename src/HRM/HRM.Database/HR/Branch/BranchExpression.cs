using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class BranchExpression
    {
        public static Expression<Func<Branch, BranchModel>> FindByIdAsync => m => new BranchModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Branch, BranchGridModel>> GridAsync => m => new BranchGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive
        };
    }
}
