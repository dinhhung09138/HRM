using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database.Common
{
    public static class MaritalStatusExpression
    {
        public static Expression<Func<MaritalStatus, MaritalStatusModel>> FindByIdAsync => m => new MaritalStatusModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<MaritalStatus, MaritalStatusGridModel>> GridAsync => m => new MaritalStatusGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
