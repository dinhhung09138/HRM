using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee Create(EmployeeModel model)
        {
            var item = new Employee(model.Id,
                model.EmployeeCode,
                model.FullName,
                model.BranchId.Value,
                model.DepartmentId,
                model.PositionId,
                model.JobPositionId,
                model.ManagerId,
                model.Email,
                model.Phone,
                model.PhoneExt,
                model.Fax,
                model.EmployeeWorkingStatusId,
                model.ProbationDate,
                model.StartWorkingDate,
                model.ResignDate,
                model.BadgeCardNumber,
                model.DateApplyBadge,
                model.FingerSignNumber,
                model.DateApplyFingerSign,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, 
                null);
            return item;
        }

        public Employee Update(EmployeeModel model)
        {
            var item = new Employee(model.Id,
                model.EmployeeCode,
                model.FullName,
                model.BranchId.Value,
                model.DepartmentId,
                model.PositionId,
                model.JobPositionId,
                model.ManagerId,
                model.Email,
                model.Phone,
                model.PhoneExt,
                model.Fax,
                model.EmployeeWorkingStatusId,
                model.ProbationDate,
                model.StartWorkingDate,
                model.ResignDate,
                model.BadgeCardNumber,
                model.DateApplyBadge,
                model.FingerSignNumber,
                model.DateApplyFingerSign,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null,
                null);
            return item;
        }
    }
}
