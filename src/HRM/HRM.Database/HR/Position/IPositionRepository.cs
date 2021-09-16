using System;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.Repositories;
using HRM.Model;
using System.Collections.Generic;

namespace HRM.Database.HR
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<PositionModel> FindByIdAsync(long id);

        Task<Grid<PositionGridModel>> GridAsync(PositionGridParameterModel paramters);

        Task<List<BaseSelectboxModel>> DropdownAsync();

        Task<bool> SaveAsync(Position model, bool isCreate);

        Task<bool> DeleteAsync(Position model);

        Task<bool> IsCurrentVersion(long id, byte[] rowVersion);
    }
}
