using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class ModelOfStudyExpression
    {
        public static Expression<Func<ModelOfStudy, ModelOfStudyModel>> FindByIdAsync => m => new ModelOfStudyModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<ModelOfStudy, ModelOfStudyGridModel>> GridAsync => m => new ModelOfStudyGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
