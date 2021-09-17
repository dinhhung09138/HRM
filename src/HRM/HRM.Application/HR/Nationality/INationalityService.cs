using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface INationalityService
    {
        Task<IResult<NationalityModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<NationalityGridModel>>> GridAsync(NationalityGridParameterModel paramters);

        Task<IResult> SaveAsync(NationalityModel model, bool isCreate);

        Task<IResult> DeleteAsync(NationalityModel model);
    }
}
