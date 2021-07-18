using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.Common
{
    public interface IProvinceRepository : IRepository<Province>
    {
        Task<ProvinceModel> FindByIdAsync(long id);

        Task<Grid<ProvinceGridModel>> GridAsync(ProvinceGridParameterModel paramters);

        Task<bool> SaveAsync(Province model, bool isCreate);

        Task<bool> DeleteAsync(Province model);
    }
}
