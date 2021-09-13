using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class EmployeeInfoExpression
    {
        public static Expression<Func<EmployeeInfo, EmployeeInfoModel>> FindByIdAsync => m => new EmployeeInfoModel()
        {
            Id = m.Id,
            EmployeeId = m.EmployeeId,
            DateOfBirth = m.DateOfBirth,
            Gender = m.Gender,
            NationalityId = m.NationalityId,
            EthnicityId = m.EthnicityId,
            ReligionId = m.ReligionId,
            MaritalStatusId = m.MaritalStatusId,
            ProfessionalQualificationId = m.ProfessionalQualificationId,
            IdCode = m.IdCode,
            IdStartDate = m.IdStartDate,
            IdExpireDate = m.IdExpireDate,
            PassportCode = m.PassportCode,
            PassportStartDate = m.PassportStartDate,
            PassportExpireDate = m.PassportExpireDate,
            DriverLicenseCode = m.DriverLicenseCode,
            DriverLicenseStartDate = m.DriverLicenseStartDate,
            DriverLicenseExpireDate = m.DriverLicenseExpireDate,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };

    }
}
