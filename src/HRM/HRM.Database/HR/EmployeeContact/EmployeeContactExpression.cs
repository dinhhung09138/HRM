using System;
using System.Collections.Generic;
using System.Linq;
using HRM.Model.HR;
using HRM.Domain.HR;
using System.Linq.Expressions;

namespace HRM.Database.HR
{
    public static class EmployeeContactExpression
    {
        public static Expression<Func<EmployeeContact, EmployeeContactModel>> FindByIdAsync => m => new EmployeeContactModel()
        {
            Id = m.Id,
            EmployeeId = m.EmployeeId,
            Phone = m.Phone,
            Email = m.Email,
            Skyper = m.Skyper,
            Zalo = m.Zalo,
            Facebook = m.Facebook,
            LinkedIn = m.LinkedIn,
            Twitter = m.Twitter,
            Github = m.Github,
            Whatsapp = m.Whatsapp,
            TemporaryAddress = m.TemporaryAddress,
            TemporaryWardId = m.TemporaryWardId,
            TemporaryDistrictId = m.TemporaryDistrictId,
            TemporaryProvinceId = m.TemporaryProvinceId,
            PermanentAddress = m.PermanentAddress,
            PermanentWardId = m.PermanentWardId,
            PermanentDistrictId = m.PermanentDistrictId,
            PermanentProvinceId = m.PermanentProvinceId,
            EmergencyName = m.EmergencyName,
            EmergencyEmail = m.EmergencyEmail,
            EmergencyPhone = m.EmergencyPhone,
            IsActive = m.IsActive,
            Deleted = m.Deleted,
            RowVersion = m.RowVersion,
        };
    }
}
