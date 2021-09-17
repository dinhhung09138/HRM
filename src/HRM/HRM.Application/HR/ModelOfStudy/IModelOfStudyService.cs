using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IModelOfStudyService
    {
        Task<IResult<ModelOfStudyModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<ModelOfStudyGridModel>>> GridAsync(ModelOfStudyGridParameterModel paramters);

        Task<IResult> SaveAsync(ModelOfStudyModel model, bool isCreate);

        Task<IResult> DeleteAsync(ModelOfStudyModel model);
    }
}
