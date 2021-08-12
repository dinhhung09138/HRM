using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.System
{
    public interface ISystemUserRepository : IRepository<SystemUser>
    {
        Task<SystemUser> GetByUserNameAsync(string userName);

        //Task<SystemUserModel> FindByIdAsync(long id);

        //Task<Grid<SystemUserGridModel>> GridAsync(SystemUserGridParameterModel paramters);

        //Task<bool> SaveAsync(SystemUser model, bool isCreate);

        //Task<bool> DeleteAsync(SystemUser model);
    }
}
