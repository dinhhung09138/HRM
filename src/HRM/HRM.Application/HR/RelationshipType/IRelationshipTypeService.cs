using System;
using HRM.Model;
using HRM.Model.HR;
using System.Threading.Tasks;
using DotNetCore.Results;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public interface IRelationshipTypeService
    {
        Task<IResult<RelationshipTypeModel>> FindByIdAsync(long id);

        Task<IResult<List<BaseSelectboxModel>>> DropdownAsync();

        Task<IResult<Grid<RelationshipTypeGridModel>>> GridAsync(RelationshipTypeGridParameterModel paramters);

        Task<IResult> SaveAsync(RelationshipTypeModel model, bool isCreate);

        Task<IResult> DeleteAsync(RelationshipTypeModel model);
    }
}
