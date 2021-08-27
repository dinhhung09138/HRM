using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Common
{
    public interface IMajorRepository : IRepository<Major>
    {
        Task<MajorModel> FindByIdAsync(long id);

        Task<Grid<MajorGridModel>> GridAsync(MajorGridParameterModel paramters);

        Task<bool> SaveAsync(Major model, bool isCreate);

        Task<bool> DeleteAsync(Major model);
    }
}
