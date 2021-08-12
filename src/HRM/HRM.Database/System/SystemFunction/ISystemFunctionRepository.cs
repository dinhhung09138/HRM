using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.System
{
    public interface ISystemFunctionRepository : IRepository<SystemFunction>
    {
        //Task<SystemFunctionModel> FindByIdAsync(long id);

        //Task<Grid<SystemFunctionGridModel>> GridAsync(SystemFunctionGridParameterModel paramters);

        //Task<bool> SaveAsync(SystemFunction model, bool isCreate);

        //Task<bool> DeleteAsync(SystemFunction model);
    }
}
