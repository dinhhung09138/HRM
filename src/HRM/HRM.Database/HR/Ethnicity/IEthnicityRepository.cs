using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IEthnicityRepository : IRepository<Ethnicity>
    {
        Task<EthnicityModel> FindByIdAsync(long id);

        Task<Grid<EthnicityGridModel>> GridAsync(EthnicityGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Ethnicity model, bool isCreate);

        Task<bool> DeleteAsync(Ethnicity model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
