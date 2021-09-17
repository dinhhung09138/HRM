using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IRankingService
    {
        Task<IResult<RankingModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<RankingGridModel>>> GridAsync(RankingGridParameterModel paramters);

        Task<IResult> SaveAsync(RankingModel model, bool isCreate);

        Task<IResult> DeleteAsync(RankingModel model);
    }
}
