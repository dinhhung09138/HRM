using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<BranchModel> FindByIdAsync(long id);

        Task<Grid<BranchGridModel>> GridAsync(BranchGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Branch model, bool isCreate);

        Task<bool> DeleteAsync(Branch model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
