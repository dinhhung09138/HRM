using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IPositionService
    {
        Task<IResult<PositionModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<PositionGridModel>>> GridAsync(PositionGridParameterModel paramters);

        Task<IResult> SaveAsync(PositionModel model, bool isCreate);

        Task<IResult> DeleteAsync(PositionModel model);
    }
}
