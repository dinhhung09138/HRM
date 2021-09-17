using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using System.Collections.Generic;
using HRM.Model;

namespace HRM.Database.HR
{
    public interface IRelationshipTypeRepository : IRepository<RelationshipType>
    {
        Task<RelationshipTypeModel> FindByIdAsync(long id);

        Task<Grid<RelationshipTypeGridModel>> GridAsync(RelationshipTypeGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(RelationshipType model, bool isCreate);

        Task<bool> DeleteAsync(RelationshipType model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
