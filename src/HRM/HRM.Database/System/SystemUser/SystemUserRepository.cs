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
    public class SystemUserRepository : EFRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(Context context) : base(context) { }

        public async Task<SystemUser> GetByUserNameAsync(string userName)
        {
            return await Queryable.FirstOrDefaultAsync(m => m.UserName == userName && m.IsActive && !m.Deleted);
        }

        public async Task<SystemUser> FindByIdAsync(long id)
        {
            return await Queryable.Where(m => m.Id == id && m.Deleted == false && m.IsActive == true)
                                  .FirstOrDefaultAsync();
        }

        //public Task<Grid<SystemUserGridModel>> GridAsync(SystemUserGridParameterModel paramters)
        //{
        //    var query = Queryable.Where(m => m.Deleted == false).AsQueryable();

        //    if (!string.IsNullOrEmpty(paramters.TextSearch))
        //    {
        //        query = query.Where(m => m.Name.ToLower().Contains(paramters.TextSearch));
        //    }

        //    var grid = query.Select(SystemUserExpression.GridAsync).GridAsync(paramters);

        //    return grid;
        //}

        //public async Task<bool> SaveAsync(SystemUser model, bool isCreate)
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

        //public async Task<bool> DeleteAsync(SystemUser model)
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
