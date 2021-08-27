using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database
{
    public static class SchoolExpression
    {
        public static Expression<Func<School, SchoolModel>> FindByIdAsync => m => new SchoolModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted
        };

        public static Expression<Func<School, SchoolGridModel>> GridAsync => m => new SchoolGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
