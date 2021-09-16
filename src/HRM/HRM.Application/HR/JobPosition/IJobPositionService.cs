using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IJobPositionService
    {
        Task<IResult<JobPositionModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<JobPositionGridModel>>> GridAsync(JobPositionGridParameterModel paramters);

        Task<IResult> SaveAsync(JobPositionModel model, bool isCreate);

        Task<IResult> DeleteAsync(JobPositionModel model);
    }
}
