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
    public class ModelOfStudyService : IModelOfStudyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModelOfStudyFactory _modelOfStudyFactory;
        private readonly IModelOfStudyRepository _modelOfStudyRepository;

        public ModelOfStudyService(
            IUnitOfWork unitOfWork,
            IModelOfStudyFactory modelOfStudyFactory,
            IModelOfStudyRepository modelOfStudyRepository)
        {
            _unitOfWork = unitOfWork;
            _modelOfStudyFactory = modelOfStudyFactory;
            _modelOfStudyRepository = modelOfStudyRepository;
        }

        public async Task<IResult<ModelOfStudyModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _modelOfStudyRepository.FindByIdAsync(id);

                return Result<ModelOfStudyModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<ModelOfStudyModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<ModelOfStudyGridModel>>> GridAsync(ModelOfStudyGridParameterModel paramters)
        {
            try
            {
                var grid = await _modelOfStudyRepository.GridAsync(paramters);
                return Result<Grid<ModelOfStudyGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _modelOfStudyRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(ModelOfStudyModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(ModelOfStudyModel model)
        {
            try
            {
                var md = await _modelOfStudyRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _modelOfStudyRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(ModelOfStudyModel model)
        {
            var validation = await new CreateModelOfStudyModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _modelOfStudyFactory.Create(model);

            await _modelOfStudyRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(ModelOfStudyModel model)
        {
            var md = await _modelOfStudyRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateModelOfStudyModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _modelOfStudyFactory.Update(model);

            await _modelOfStudyRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(ModelOfStudyModel model)
        {
            if (await _modelOfStudyRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
