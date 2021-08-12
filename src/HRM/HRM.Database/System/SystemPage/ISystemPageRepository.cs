using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.System
{
    public interface ISystemPageRepository : IRepository<SystemPage>
    {
        //Task<SystemPageModel> FindByIdAsync(long id);

        //Task<Grid<SystemPageGridModel>> GridAsync(SystemPageGridParameterModel paramters);

        //Task<bool> SaveAsync(SystemPage model, bool isCreate);

        //Task<bool> DeleteAsync(SystemPage model);
    }
}
