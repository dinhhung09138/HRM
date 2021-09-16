using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IJobPositionRepository : IRepository<JobPosition>
    {
        Task<JobPositionModel> FindByIdAsync(long id);

        Task<Grid<JobPositionGridModel>> GridAsync(JobPositionGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(JobPosition model, bool isCreate);

        Task<bool> DeleteAsync(JobPosition model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
