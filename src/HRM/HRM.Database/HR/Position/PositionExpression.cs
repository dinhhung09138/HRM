using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class PositionExpression
    {
        public static Expression<Func<Position, PositionModel>> FindByIdAsync => m => new PositionModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Position, PositionGridModel>> GridAsync => m => new PositionGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            IsActive = m.IsActive
        };
    }
}
