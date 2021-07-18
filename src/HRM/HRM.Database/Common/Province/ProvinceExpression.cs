using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database.Common
{
    public static class ProvinceExpression
    {
        public static Expression<Func<Province, ProvinceModel>> FindByIdAsync => m => new ProvinceModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted
        };

        public static Expression<Func<Province, ProvinceGridModel>> GridAsync => m => new ProvinceGridModel()
        {
            Id = m.Id,
            Name = m.Name
        };
    }
}
