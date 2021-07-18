using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database.Common
{
    public class WardExpression
    {
        public static Expression<Func<Ward, WardModel>> FindByIdAsync => m => new WardModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted
        };

        public static Expression<Func<Ward, WardGridModel>> GridAsync => m => new WardGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            DistrictName = m.District.Name,
            ProvinceName = m.District.Province.Name
        };
    }
}
