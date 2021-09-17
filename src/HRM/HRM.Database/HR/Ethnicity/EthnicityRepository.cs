using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;
using System.Linq;

namespace HRM.Database.HR
{
    public sealed class EthnicityRepository : EFRepository<Ethnicity>, IEthnicityRepository
    {
        public EthnicityRepository(Context context) : base(context) { }

        public async Task<EthnicityModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(EthnicityExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<EthnicityGridModel>> GridAsync(EthnicityGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
            }

            query = query.OrderBy(m => m.Precedence);

            var grid = await query.Select(EthnicityExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<EthnicityGridModel>();

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

        public async Task<bool> SaveAsync(Ethnicity model, bool isCreate)
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
                    model.IsActive,
                    model.Precedence,
                    model.UpdateBy,
                    model.UpdateDate
                });
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Ethnicity model)
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
