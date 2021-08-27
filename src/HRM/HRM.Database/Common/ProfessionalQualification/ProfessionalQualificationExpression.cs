using System;
using HRM.Model.Common;
using HRM.Domain.Common;
using System.Linq.Expressions;

namespace HRM.Database.Common
{
    public class ProfessionalQualificationExpression
    {
        public static Expression<Func<ProfessionalQualification, ProfessionalQualificationModel>> FindByIdAsync => m => new ProfessionalQualificationModel()
        {
            Id = m.Id,
            Name = m.Name,
            IsActive = m.IsActive,
            Precedence = m.Precedence,
            Deleted = m.Deleted
        };

        public static Expression<Func<ProfessionalQualification, ProfessionalQualificationGridModel>> GridAsync => m => new ProfessionalQualificationGridModel()
        {
            Id = m.Id,
            Name = m.Name,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
