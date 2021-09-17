using System;
using System.Linq;
using HRM.Database.HR;
using HRM.Model;
using HRM.Model.HR;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using System.Collections.Generic;

namespace HRM.Application.HR
{
    public class RelationshipTypeService : IRelationshipTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelationshipTypeFactory _relationshipTypeFactory;
        private readonly IRelationshipTypeRepository _relationshipTypeRepository;

        public RelationshipTypeService(
            IUnitOfWork unitOfWork,
            IRelationshipTypeFactory relationshipTypeFactory,
            IRelationshipTypeRepository relationshipTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _relationshipTypeFactory = relationshipTypeFactory;
            _relationshipTypeRepository = relationshipTypeRepository;
        }

        public async Task<IResult<RelationshipTypeModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _relationshipTypeRepository.FindByIdAsync(id);

                return Result<RelationshipTypeModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<RelationshipTypeModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<RelationshipTypeGridModel>>> GridAsync(RelationshipTypeGridParameterModel paramters)
        {
            try
            {
                var grid = await _relationshipTypeRepository.GridAsync(paramters);
                return Result<Grid<RelationshipTypeGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _relationshipTypeRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(RelationshipTypeModel model, bool isCreate)
        {
            try
            {
                if (isCreate == true)
                {
                    return await Create(model);
                }
                else
                {
                    return await Update(model);
                }

            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(RelationshipTypeModel model)
        {
            try
            {
                var md = await _relationshipTypeRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _relationshipTypeRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(RelationshipTypeModel model)
        {
            var validation = await new CreateRelationshipTypeModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _relationshipTypeFactory.Create(model);

            await _relationshipTypeRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(RelationshipTypeModel model)
        {
            var md = await _relationshipTypeRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateRelationshipTypeModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _relationshipTypeFactory.Update(model);

            await _relationshipTypeRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(RelationshipTypeModel model)
        {
            if (await _relationshipTypeRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
