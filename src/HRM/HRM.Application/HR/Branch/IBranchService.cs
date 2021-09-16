using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IBranchService
    {
        Task<IResult<BranchModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<BranchGridModel>>> GridAsync(BranchGridParameterModel paramters);

        Task<IResult> SaveAsync(BranchModel model, bool isCreate);

        Task<IResult> DeleteAsync(BranchModel model);
    }
}
