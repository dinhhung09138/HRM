using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database.Common
{
    public static class MajorExpression
    {
        public static Expression<Func<Major, MajorModel>> FindByIdAsync => m => new MajorModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted
        };

        public static Expression<Func<Major, MajorGridModel>> GridAsync => m => new MajorGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
