using System;
using HRM.Model.Common;
using System.Threading.Tasks;
using DotNetCore.Results;
using DotNetCore.Objects;

namespace HRM.Application.Common
{
    public interface ICertificatedService
    {
        Task<IResult<CertificatedModel>> FindByIdAsync(long id);

        Task<IResult<Grid<CertificatedGridModel>>> GridAsync(CertificatedGridParameterModel paramters);

        Task<IResult> SaveAsync(CertificatedModel model, bool isCreate);

        Task<IResult> DeleteAsync(CertificatedModel model);
    }
}
