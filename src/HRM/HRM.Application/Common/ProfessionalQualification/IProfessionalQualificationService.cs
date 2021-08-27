using System;
using HRM.Model;
using HRM.Model.Common;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Common
{
    public interface IProfessionalQualificationService
    {
        Task<IResult<ProfessionalQualificationModel>> FindByIdAsync(long id);

        Task<IResult<Grid<ProfessionalQualificationGridModel>>> GridAsync(ProfessionalQualificationGridParameterModel paramters);

        Task<IResult> SaveAsync(ProfessionalQualificationModel model, bool isCreate);

        Task<IResult> DeleteAsync(ProfessionalQualificationModel model);
    }
}
