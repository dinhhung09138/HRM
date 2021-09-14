using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeContactFactory : IEmployeeContactFactory
    {
        public EmployeeContact Create(EmployeeContactModel model)
        {
            var item = new EmployeeContact(model.Id,
                model.EmployeeId,
                model.Phone,
                model.Mobile,
                model.Email,
                model.Skyper,
                model.Zalo,
                model.Facebook,
                model.LinkedIn,
                model.Twitter,
                model.Github,
                model.Whatsapp,
                model.TemporaryAddress,
                model.TemporaryWardId,
                model.TemporaryDistrictId,
                model.TemporaryProvinceId,
                model.PermanentAddress,
                model.PermanentWardId,
                model.PermanentDistrictId,
                model.PermanentProvinceId,
                model.EmergencyName,
                model.EmergencyPhone,
                model.EmergencyEmail,
                true,
                model.CreateBy,
                DateTime.Now,
                null,
                null);
            return item;
        }

        public EmployeeContact Update(EmployeeContactModel model)
        {
            var item = new EmployeeContact(model.Id,
                model.EmployeeId,
                model.Phone,
                model.Mobile,
                model.Email,
                model.Skyper,
                model.Zalo,
                model.Facebook,
                model.LinkedIn,
                model.Twitter,
                model.Github,
                model.Whatsapp,
                model.TemporaryAddress,
                model.TemporaryWardId,
                model.TemporaryDistrictId,
                model.TemporaryProvinceId,
                model.PermanentAddress,
                model.PermanentWardId,
                model.PermanentDistrictId,
                model.PermanentProvinceId,
                model.EmergencyName,
                model.EmergencyPhone,
                model.EmergencyEmail,
                true,
                model.CreateBy,
                DateTime.Now,
                null,
                null);
            return item;
        }
    }
}
