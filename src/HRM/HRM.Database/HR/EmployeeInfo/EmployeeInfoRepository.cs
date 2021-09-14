using System;
using System.Linq;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM.Database.HR
{
    public sealed class EmployeeInfoRepository : EFRepository<EmployeeInfo>, IEmployeeInfoRepository
    {
        public EmployeeInfoRepository(Context context) : base(context) { }

        public async Task<EmployeeInfoModel> FindByEmployeeIdAsync(long employeeId)
        {
            return await Queryable.Where(m => m.EmployeeId == employeeId && m.Deleted == false).Select(EmployeeInfoExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync(EmployeeInfo model, bool isCreate)
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
