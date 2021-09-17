using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class ReligionExpression
    {
        public static Expression<Func<Religion, ReligionModel>> FindByIdAsync => m => new ReligionModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Religion, ReligionGridModel>> GridAsync => m => new ReligionGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
