using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class NationalityExpression
    {
        public static Expression<Func<Nationality, NationalityModel>> FindByIdAsync => m => new NationalityModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Nationality, NationalityGridModel>> GridAsync => m => new NationalityGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
