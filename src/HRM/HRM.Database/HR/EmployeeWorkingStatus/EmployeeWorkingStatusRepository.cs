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
    public sealed class EmployeeWorkingStatusRepository : EFRepository<EmployeeWorkingStatus>, IEmployeeWorkingStatusRepository
    {
        public EmployeeWorkingStatusRepository(Context context) : base(context) { }

        public async Task<EmployeeWorkingStatusModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(EmployeeWorkingStatusExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<EmployeeWorkingStatusGridModel>> GridAsync(EmployeeWorkingStatusGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch)
                                        || m.Description.ToLower().Contains(paramters.TextSearch));
            }

            query = query.OrderBy(m => m.Name);

            var grid = await query.Select(EmployeeWorkingStatusExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<EmployeeWorkingStatusGridModel>();

            result.Count = grid.Count;
            result.List = grid.List;
            result.Parameters = grid.Parameters;

            return result;
        }

        public async Task<List<BaseSelectboxModel>> DropdownAsync()
        {
            return await Queryable.Where(m => m.IsActive && !m.Deleted)
                                   .OrderBy(m => m.Name)
                                   .Select(m => new BaseSelectboxModel()
                                   {
                                       Id = m.Id.ToString(),
                                       Name = m.Name
                                   })
                                   .ToListAsync();
        }

        public async Task<bool> SaveAsync(EmployeeWorkingStatus model, bool isCreate)
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
                    model.Name,
                    model.Description,
                    model.IsActive,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(EmployeeWorkingStatus model)
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
