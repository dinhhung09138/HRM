using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.System
{
    public interface ISystemUserRoleRepository : IRepository<SystemUserRole>
    {
        //Task<SystemUserRoleModel> FindByIdAsync(long id);

        //Task<Grid<SystemUserRoleGridModel>> GridAsync(SystemUserRoleGridParameterModel paramters);

        //Task<bool> SaveAsync(SystemUserRole model, bool isCreate);

        //Task<bool> DeleteAsync(SystemUserRole model);
    }
}
