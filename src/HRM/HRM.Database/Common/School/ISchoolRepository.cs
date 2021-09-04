using System;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Common
{
    public interface ISchoolRepository : IRepository<School>
    {
        Task<SchoolModel> FindByIdAsync(long id);

        Task<Grid<SchoolGridModel>> GridAsync(SchoolGridParameterModel paramters);

        Task<bool> SaveAsync(School model, bool isCreate);

        Task<bool> DeleteAsync(School model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
