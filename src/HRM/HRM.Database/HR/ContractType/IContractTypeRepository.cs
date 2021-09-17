using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IContractTypeRepository : IRepository<ContractType>
    {
        Task<ContractTypeModel> FindByIdAsync(long id);

        Task<Grid<ContractTypeGridModel>> GridAsync(ContractTypeGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> IsExistingCode(long? id, string code);

        Task<bool> SaveAsync(ContractType model, bool isCreate);

        Task<bool> DeleteAsync(ContractType model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
