using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IEthnicityService
    {
        Task<IResult<EthnicityModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<EthnicityGridModel>>> GridAsync(EthnicityGridParameterModel paramters);

        Task<IResult> SaveAsync(EthnicityModel model, bool isCreate);

        Task<IResult> DeleteAsync(EthnicityModel model);
    }
}
