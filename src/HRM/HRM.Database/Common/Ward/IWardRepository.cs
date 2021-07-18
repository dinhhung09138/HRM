using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.Common
{
    public interface IWardRepository : IRepository<Ward>
    {
        Task<WardModel> FindByIdAsync(long id);

        Task<Grid<WardGridModel>> GridAsync(WardGridParameterModel paramters);

        Task<bool> SaveAsync(Ward model, bool isCreate);

        Task<bool> DeleteAsync(Ward model);
    }
}
