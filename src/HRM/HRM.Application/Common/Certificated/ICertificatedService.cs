using System;
using HRM.Model.Common;
using System.Threading.Tasks;
using DotNetCore.Results;

namespace HRM.Application.Common
{
    public interface ICertificatedService
    {
        Task<IResult> FindByIdAsync(long id);

        Task<IResult> GridAsync(CertificatedGridParameterModel paramters);

        Task<IResult> SaveAsync(CertificatedModel model, bool isCreate);

        Task<IResult> DeleteAsync(CertificatedModel model);
    }
}
