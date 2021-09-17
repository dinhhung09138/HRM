using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IReligionRepository : IRepository<Religion>
    {
        Task<ReligionModel> FindByIdAsync(long id);

        Task<Grid<ReligionGridModel>> GridAsync(ReligionGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Religion model, bool isCreate);

        Task<bool> DeleteAsync(Religion model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
