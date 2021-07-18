using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database.Common
{
    public class DistrictExpression
    {
        public static Expression<Func<District, DistrictModel>> FindByIdAsync => m => new DistrictModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted
        };

        public static Expression<Func<District, DistrictGridModel>> GridAsync => m => new DistrictGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            ProvinceName = m.Province.Name
        };
    }
}
