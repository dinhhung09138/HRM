using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        Task<NationalityModel> FindByIdAsync(long id);

        Task<Grid<NationalityGridModel>> GridAsync(NationalityGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Nationality model, bool isCreate);

        Task<bool> DeleteAsync(Nationality model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
