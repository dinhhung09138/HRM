using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;
using HRM.Model;

namespace HRM.Database.HR
{
    public sealed class EmployeeContactRepository : EFRepository<EmployeeContact>, IEmployeeContactRepository
    {
        public EmployeeContactRepository(Context context) : base(context) { }

        public async Task<EmployeeContactModel> FindByEmployeeIdAsync(long employeeId)
        {
            return await Queryable.Where(m => m.EmployeeId == employeeId && m.Deleted == false).Select(EmployeeContactExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync(EmployeeContact model, bool isCreate)
        {
            if (isCreate == true)
            {
                await AddAsync(model);
            }
            else
            {
                await UpdatePartialAsync(new
                {
                    model.Id,
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
                    model.EmergencyEmail,
                    model.EmergencyPhone,
                    model.IsActive,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> IsCurrentVersion(long id, byte[] rowVersion)
        {
            return await Queryable.AnyAsync(m => !m.Deleted && m.Id == id && m.RowVersion == rowVersion);
        }

    }
}
