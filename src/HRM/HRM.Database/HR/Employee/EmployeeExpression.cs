using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class EmployeeExpression
    {
        public static Expression<Func<Employee, EmployeeModel>> FindByIdAsync => m => new EmployeeModel()
        {
            Id = m.Id,
            EmployeeCode = m.EmployeeCode,
            FullName = m.FullName,
            BranchId = m.BranchId,
            BranchIdValue = m.BranchId.ToString(),
            DepartmentId = m.DepartmentId,
            PositionId = m.PositionId,
            JobPositionId = m.JobPositionId,
            ManagerId = m.ManagerId,
            Email = m.Email,
            Phone = m.Phone,
            PhoneExt = m.PhoneExt,
            Fax = m.Fax,
            EmployeeWorkingStatusId = m.EmployeeWorkingStatusId,
            ProbationDate = m.ProbationDate,
            StartWorkingDate = m.StartWorkingDate,
            ResignDate = m.ResignDate,
            BadgeCardNumber = m.BadgeCardNumber,
            DateApplyBadge = m.DateApplyBadge,
            FingerSignNumber = m.FingerSignNumber,
            DateApplyFingerSign = m.DateApplyFingerSign,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

        public static Expression<Func<Employee, EmployeeGridModel>> GridAsync => m => new EmployeeGridModel()
        {
            Id = m.Id,
            Name = m.FullName,
            Phone = m.Phone,
            Email = m.Email,
            Avatar = string.Empty, // TODO
            Code = m.EmployeeCode,
            Position = string.Empty, // TODO
            TypeOfWork = string.Empty, // TODO
            IsActive = m.IsActive
        };
    }
}
