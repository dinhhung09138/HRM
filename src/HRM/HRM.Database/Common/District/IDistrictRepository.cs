using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Objects;
using DotNetCore.Repositories;

namespace HRM.Database.Common
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<DistrictModel> FindByIdAsync(long id);

        Task<Grid<DistrictGridModel>> GridAsync(DistrictGridParameterModel paramters);

        Task<bool> SaveAsync(District model, bool isCreate);

        Task<bool> DeleteAsync(District model);
    }
}
