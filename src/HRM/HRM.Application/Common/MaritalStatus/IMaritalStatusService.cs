using System;
using HRM.Model;
using HRM.Model.Common;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Common
{
    public interface IMaritalStatusService
    {
        Task<IResult<MaritalStatusModel>> FindByIdAsync(long id);

        Task<IResult<Grid<MaritalStatusGridModel>>> GridAsync(MaritalStatusGridParameterModel paramters);

        Task<IResult> SaveAsync(MaritalStatusModel model, bool isCreate);

        Task<IResult> DeleteAsync(MaritalStatusModel model);
    }
}
