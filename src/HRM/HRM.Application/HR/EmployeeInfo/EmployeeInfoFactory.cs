using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeInfoFactory : IEmployeeInfoFactory
    {
        public EmployeeInfo Create(EmployeeInfoModel model)
        {
            var item = new EmployeeInfo(model.Id,
                model.EmployeeId,
                model.DateOfBirth,
                model.Gender,
                model.NationalityId,
                model.EthnicityId,
                model.ReligionId,
                model.MaritalStatusId,
                model.ProfessionalQualificationId,
                model.IdCode,
                model.IdStartDate,
                model.IdExpireDate,
                model.PassportCode,
                model.PassportStartDate,
                model.PassportExpireDate,
                model.DriverLicenseCode,
                model.DriverLicenseStartDate,
                model.DriverLicenseExpireDate,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null,
                null);
            return item;
        }

        public EmployeeInfo Update(EmployeeInfoModel model)
        {
            var item = new EmployeeInfo(model.Id,
                model.EmployeeId,
                model.DateOfBirth,
                model.Gender,
                model.NationalityId,
                model.EthnicityId,
                model.ReligionId,
                model.MaritalStatusId,
                model.ProfessionalQualificationId,
                model.IdCode,
                model.IdStartDate,
                model.IdExpireDate,
                model.PassportCode,
                model.PassportStartDate,
                model.PassportExpireDate,
                model.DriverLicenseCode,
                model.DriverLicenseStartDate,
                model.DriverLicenseExpireDate,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null,
                null);
            return item;
        }
    }
}
