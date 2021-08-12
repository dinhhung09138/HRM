using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;
using System.Linq;

namespace HRM.Database.System
{
    public class SystemFunctionRepository : EFRepository<SystemFunction>, ISystemFunctionRepository
    {
        public SystemFunctionRepository(Context context) : base(context) { }

        //public async Task<SystemFunctionModel> FindByIdAsync(long id)
        //{
        //    return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(SystemFunctionExpression.FindByIdAsync).FirstOrDefaultAsync();
        //}

        //public Task<Grid<SystemFunctionGridModel>> GridAsync(SystemFunctionGridParameterModel paramters)
        //{
        //    var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

        //    if (!string.IsNullOrEmpty(paramters.TextSearch))
        //    {
        //        query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
        //    }

        //    var grid = query.Select(SystemFunctionExpression.GridAsync).GridAsync(paramters);

        //    return grid;
        //}

        //public async Task<bool> SaveAsync(SystemFunction model, bool isCreate)
        //{
        //    if (isCreate == true)
        //    {
        //        await AddAsync(model);
        //    }
        //    else
        //    {
        //        await UpdatePartialAsync(new
        //        {
        //            model.Id,
        //            model.Name,
        //            model.IsActive,
        //            model.Precedence,
        //            model.UpdateBy,
        //            model.UpdateDate
        //        });
        //    }

        //    return true;
        //}

        //public async Task<bool> DeleteAsync(SystemFunction model)
        //{
        //    await UpdatePartialAsync(new
        //    {
        //        model.Id,
        //        model.Deleted,
        //        model.UpdateBy,
        //        model.UpdateDate
        //    });

        //    return true;
        //}

    }
}
