using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class RelationshipTypeExpression
    {
        public static Expression<Func<RelationshipType, RelationshipTypeModel>> FindByIdAsync => m => new RelationshipTypeModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<RelationshipType, RelationshipTypeGridModel>> GridAsync => m => new RelationshipTypeGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
