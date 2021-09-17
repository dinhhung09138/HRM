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
    public class RankingService : IRankingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRankingFactory _rankingFactory;
        private readonly IRankingRepository _rankingRepository;

        public RankingService(
            IUnitOfWork unitOfWork,
            IRankingFactory rankingFactory,
            IRankingRepository rankingRepository)
        {
            _unitOfWork = unitOfWork;
            _rankingFactory = rankingFactory;
            _rankingRepository = rankingRepository;
        }

        public async Task<IResult<RankingModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _rankingRepository.FindByIdAsync(id);

                return Result<RankingModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<RankingModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<RankingGridModel>>> GridAsync(RankingGridParameterModel paramters)
        {
            try
            {
                var grid = await _rankingRepository.GridAsync(paramters);
                return Result<Grid<RankingGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _rankingRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(RankingModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(RankingModel model)
        {
            try
            {
                var md = await _rankingRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _rankingRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(RankingModel model)
        {
            var validation = await new CreateRankingModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _rankingFactory.Create(model);

            await _rankingRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(RankingModel model)
        {
            var md = await _rankingRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateRankingModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _rankingFactory.Update(model);

            await _rankingRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(RankingModel model)
        {
            if (await _rankingRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
