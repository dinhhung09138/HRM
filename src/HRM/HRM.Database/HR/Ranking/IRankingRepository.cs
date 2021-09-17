using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IRankingRepository : IRepository<Ranking>
    {
        Task<RankingModel> FindByIdAsync(long id);

        Task<Grid<RankingGridModel>> GridAsync(RankingGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Ranking model, bool isCreate);

        Task<bool> DeleteAsync(Ranking model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
