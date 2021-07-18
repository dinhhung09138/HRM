using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DotNetCore.Objects;

namespace HRM.Database.Common
{
    public class ProvinceRepository : EFRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(Context context) : base(context) { }

        public async Task<ProvinceModel> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id).Select(ProvinceExpression.FindByIdAsync).FirstOrDefaultAsync();
        }

        public Task<Grid<ProvinceGridModel>> GridAsync(ProvinceGridParameterModel paramters)
        {
            var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(paramters.TextSearch))
            {
                query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
            }

            var grid = query.Select(ProvinceExpression.GridAsync).GridAsync(paramters);

            return grid;
        }

        public async Task<bool> SaveAsync(Province model, bool isCreate)
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


        public async Task<bool> DeleteAsync(Province model)
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

    }
}
