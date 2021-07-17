using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using DotNetCore.Objects;

namespace HRM.Database.Common
{
    public interface ICertificatedRepository : IRepository<Certificated>
    {
        Task<CertificatedModel> FindByIdAsync(long id);

        Task<Grid<CertificatedGridModel>> GridAsync(CertificatedGridParameterModel paramters);

        Task<bool> SaveAsync(Certificated model, bool isCreate);

        Task<bool> DeleteAsync(Certificated model);
    }
}
