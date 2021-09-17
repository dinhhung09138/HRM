using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IContractTypeService
    {
        Task<IResult<ContractTypeModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<ContractTypeGridModel>>> GridAsync(ContractTypeGridParameterModel paramters);

        Task<IResult> SaveAsync(ContractTypeModel model, bool isCreate);

        Task<IResult> DeleteAsync(ContractTypeModel model);
    }
}
