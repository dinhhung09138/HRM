using System;
using HRM.Model;
using HRM.Model.Common;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Common
{
    public interface IMajorService
    {
        Task<IResult<MajorModel>> FindByIdAsync(long id);

        Task<IResult<Grid<MajorGridModel>>> GridAsync(MajorGridParameterModel paramters);

        Task<IResult> SaveAsync(MajorModel model, bool isCreate);

        Task<IResult> DeleteAsync(MajorModel model);
    }
}
