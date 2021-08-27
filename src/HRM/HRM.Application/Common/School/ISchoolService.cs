using System;
using HRM.Model;
using HRM.Model.Common;
using System.Threading.Tasks;
using DotNetCore.Results;


namespace HRM.Application.Common
{
    public interface ISchoolService
    {
        Task<IResult<SchoolModel>> FindByIdAsync(long id);

        Task<IResult<Grid<SchoolGridModel>>> GridAsync(SchoolGridParameterModel paramters);

        Task<IResult> SaveAsync(SchoolModel model, bool isCreate);

        Task<IResult> DeleteAsync(SchoolModel model);
    }
}
