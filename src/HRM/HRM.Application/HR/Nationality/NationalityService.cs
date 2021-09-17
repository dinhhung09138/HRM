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
    public class NationalityService : INationalityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INationalityFactory _nationalityFactory;
        private readonly INationalityRepository _nationalityRepository;

        public NationalityService(
            IUnitOfWork unitOfWork,
            INationalityFactory nationalityFactory,
            INationalityRepository nationalityRepository)
        {
            _unitOfWork = unitOfWork;
            _nationalityFactory = nationalityFactory;
            _nationalityRepository = nationalityRepository;
        }

        public async Task<IResult<NationalityModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _nationalityRepository.FindByIdAsync(id);

                return Result<NationalityModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<NationalityModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<NationalityGridModel>>> GridAsync(NationalityGridParameterModel paramters)
        {
            try
            {
                var grid = await _nationalityRepository.GridAsync(paramters);
                return Result<Grid<NationalityGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _nationalityRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(NationalityModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(NationalityModel model)
        {
            try
            {
                var md = await _nationalityRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _nationalityRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(NationalityModel model)
        {
            var validation = await new CreateNationalityModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _nationalityFactory.Create(model);

            await _nationalityRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(NationalityModel model)
        {
            var md = await _nationalityRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateNationalityModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _nationalityFactory.Update(model);

            await _nationalityRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(NationalityModel model)
        {
            if (await _nationalityRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
