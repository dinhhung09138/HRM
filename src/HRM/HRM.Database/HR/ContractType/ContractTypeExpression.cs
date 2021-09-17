using System;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class ContractTypeExpression
    {
        public static Expression<Func<ContractType, ContractTypeModel>> FindByIdAsync => m => new ContractTypeModel()
        {
            Id = m.Id,
            Code = m.Code,
            Name = m.Name,
            Description = m.Description,
            AllowInsurance = m.AllowInsurance,
            AllowLeaveDate = m.AllowLeaveDate,
            Precedence = m.Precedence,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<ContractType, ContractTypeGridModel>> GridAsync => m => new ContractTypeGridModel()
        {
            Id = m.Id,
            Code = m.Code,
            Name = m.Name,
            Description = m.Description,
            AllowInsurance = m.AllowInsurance,
            AllowLeaveDate = m.AllowLeaveDate,
            Precedence = m.Precedence,
            IsActive = m.IsActive
        };
    }
}
