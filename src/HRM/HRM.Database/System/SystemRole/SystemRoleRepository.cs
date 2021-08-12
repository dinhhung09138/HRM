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
    public class SystemRoleRepository : EFRepository<SystemRole>, ISystemRoleRepository
    {
        public SystemRoleRepository(Context context) : base(context) { }

        //public async Task<SystemRoleModel> FindByIdAsync(long id)
        //{
        //    return await Queryable.Where(m => m.Id == id && m.Deleted == false).Select(SystemRoleExpression.FindByIdAsync).FirstOrDefaultAsync();
        //}

        //public Task<Grid<SystemRoleGridModel>> GridAsync(SystemRoleGridParameterModel paramters)
        //{
        //    var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

        //    if (!string.IsNullOrEmpty(paramters.TextSearch))
        //    {
        //        query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
        //    }

        //    var grid = query.Select(SystemRoleExpression.GridAsync).GridAsync(paramters);

        //    return grid;
        //}

        //public async Task<bool> SaveAsync(SystemRole model, bool isCreate)
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

        //public async Task<bool> DeleteAsync(SystemRole model)
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
