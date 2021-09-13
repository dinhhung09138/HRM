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
    public sealed class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context) { }

        public async Task<EmployeeModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(EmployeeExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<EmployeeGridModel>> GridAsync(EmployeeGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.FullName.ToLower().Contains(paramters.TextSearch)
                                        || m.EmployeeCode.ToLower().Contains(paramters.TextSearch)
                                        || m.Email.ToLower().Contains(paramters.TextSearch)
                                        || m.Phone.ToLower().Contains(paramters.TextSearch)
                                        || m.Fax.ToLower().Contains(paramters.TextSearch));
            }

            query = query.OrderBy(m => m.FullName);

            var grid = await query.Select(EmployeeExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<EmployeeGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<List<BaseSelectboxModel>> DropdownAsync()
        {
            return await Queryable.Where(m => m.IsActive && !m.Deleted)
                                   .OrderBy(m => m.FullName)
                                   .Select(m => new BaseSelectboxModel()
                                   {
                                       Id = m.Id.ToString(),
                                       Name = m.FullName
                                   })
                                   .ToListAsync();
        }

        public async Task<bool> SaveAsync(Employee model, bool isCreate)
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
                    model.EmployeeCode,
                    model.FullName,
                    model.BranchId,
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
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Employee model)
        {
            await UpdatePartialAsync(new
            {
                model.Id,
                model.Deleted,
                model.UpdateBy,
                model.UpdateDate
            });

            return true;
        }

        public async Task<bool> IsCurrentVersion(long id, byte[] rowVersion)
        {
            return await Queryable.AnyAsync(m => !m.Deleted && m.Id == id && m.RowVersion == rowVersion);
        }

    }
}
