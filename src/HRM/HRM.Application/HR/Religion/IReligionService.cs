using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IReligionService
    {
        Task<IResult<ReligionModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<ReligionGridModel>>> GridAsync(ReligionGridParameterModel paramters);

        Task<IResult> SaveAsync(ReligionModel model, bool isCreate);

        Task<IResult> DeleteAsync(ReligionModel model);
    }
}
