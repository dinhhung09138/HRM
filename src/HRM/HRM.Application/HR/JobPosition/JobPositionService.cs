using System;
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
    public class JobPositionService : IJobPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJobPositionFactory _jobPositionFactory;
        private readonly IJobPositionRepository _jobPositionRepository;

        public JobPositionService(
            IUnitOfWork unitOfWork,
            IJobPositionFactory jobPositionFactory,
            IJobPositionRepository jobPositionRepository)
        {
            _unitOfWork = unitOfWork;
            _jobPositionFactory = jobPositionFactory;
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<IResult<JobPositionModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _jobPositionRepository.FindByIdAsync(id);

                return Result<JobPositionModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<JobPositionModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<JobPositionGridModel>>> GridAsync(JobPositionGridParameterModel paramters)
        {
            try
            {
                var grid = await _jobPositionRepository.GridAsync(paramters);
                return Result<Grid<JobPositionGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _jobPositionRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(JobPositionModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(JobPositionModel model)
        {
            try
            {
                var md = await _jobPositionRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _jobPositionRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(JobPositionModel model)
        {
            var validation = await new CreateJobPositionModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _jobPositionFactory.Create(model);

            await _jobPositionRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(JobPositionModel model)
        {
            var md = await _jobPositionRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateJobPositionModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _jobPositionFactory.Update(model);

            await _jobPositionRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(JobPositionModel model)
        {
            if (await _jobPositionRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
