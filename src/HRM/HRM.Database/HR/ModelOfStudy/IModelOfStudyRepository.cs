using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IModelOfStudyRepository : IRepository<ModelOfStudy>
    {
        Task<ModelOfStudyModel> FindByIdAsync(long id);

        Task<Grid<ModelOfStudyGridModel>> GridAsync(ModelOfStudyGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(ModelOfStudy model, bool isCreate);

        Task<bool> DeleteAsync(ModelOfStudy model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
