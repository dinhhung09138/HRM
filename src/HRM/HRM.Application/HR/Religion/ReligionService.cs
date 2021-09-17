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
    public class ReligionService : IReligionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReligionFactory _religionFactory;
        private readonly IReligionRepository _religionRepository;

        public ReligionService(
            IUnitOfWork unitOfWork,
            IReligionFactory religionFactory,
            IReligionRepository religionRepository)
        {
            _unitOfWork = unitOfWork;
            _religionFactory = religionFactory;
            _religionRepository = religionRepository;
        }

        public async Task<IResult<ReligionModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _religionRepository.FindByIdAsync(id);

                return Result<ReligionModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<ReligionModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<ReligionGridModel>>> GridAsync(ReligionGridParameterModel paramters)
        {
            try
            {
                var grid = await _religionRepository.GridAsync(paramters);
                return Result<Grid<ReligionGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _religionRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(ReligionModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(ReligionModel model)
        {
            try
            {
                var md = await _religionRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _religionRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(ReligionModel model)
        {
            var validation = await new CreateReligionModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _religionFactory.Create(model);

            await _religionRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(ReligionModel model)
        {
            var md = await _religionRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateReligionModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _religionFactory.Update(model);

            await _religionRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(ReligionModel model)
        {
            if (await _religionRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
