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
    public sealed class ContractTypeRepository : EFRepository<ContractType>, IContractTypeRepository
    {
        public ContractTypeRepository(Context context) : base(context) { }

        public async Task<ContractTypeModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(ContractTypeExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public async Task<Model.Grid<ContractTypeGridModel>> GridAsync(ContractTypeGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
            }

            query = query.OrderBy(m => m.Precedence);

            var grid = await query.Select(ContractTypeExpression.GridAsync).GridAsync(paramters);

            var result = new Model.Grid<ContractTypeGridModel>();

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

        public async Task<bool> IsExistingCode(long? id, string code)
        {
            if (id.HasValue)
            {
                return await Queryable.AnyAsync(m => !m.Deleted && m.Id != id && m.Code == code);
            }
            return await Queryable.AllAsync(m => m.Code == code && !m.Deleted);
        }

        public async Task<bool> SaveAsync(ContractType model, bool isCreate)
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

        public async Task<bool> DeleteAsync(ContractType model)
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
