using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.System
{
    public interface ISystemRoleRepository : IRepository<SystemRole>
    {
        //Task<SystemRoleModel> FindByIdAsync(long id);

        //Task<Grid<SystemRoleGridModel>> GridAsync(SystemRoleGridParameterModel paramters);

        //Task<bool> SaveAsync(SystemRole model, bool isCreate);

        //Task<bool> DeleteAsync(SystemRole model);
    }
}
