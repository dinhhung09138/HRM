using System;
using System.Linq;
using HRM.Database.Assets;
using HRM.Model;
using HRM.Model.Assets;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using HRM.Infrastructure.Services;

namespace HRM.Application.Assets
{
    public sealed class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssetFactory _assetFactory;
        private readonly IAssetRepository _assetRepository;

        public AssetService(
            IUnitOfWork unitOfWork,
            IAssetFactory assetFactory,
            IAssetRepository assetRepository)
        {
            _unitOfWork = unitOfWork;
            _assetFactory = assetFactory;
            _assetRepository = assetRepository;
        }

        public async Task<IResult<AssetModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _assetRepository.FindByIdAsync(id);

                return Result<AssetModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<AssetModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<AssetGridModel>>> GridAsync(AssetGridParameterModel paramters)
        {
            try
            {
                var grid = await _assetRepository.GridAsync(paramters);
                return Result<Grid<AssetGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(AssetModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(AssetModel model)
        {
            try
            {
                var md = await _assetRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _assetRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(AssetModel model)
        {
            var validation = await new CreateAssetModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            if (await _assetRepository.IsExistingCode(model.Id, model.Code))
            {
                return Result.Fail(Constant.Message.CODE_IS_EXISTS);
            }

            model.FixingCost = 0;
            model.MantenanceCost = 0;
            var md = _assetFactory.Create(model);

            await _assetRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(AssetModel model)
        {
            var md = await _assetRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            if (await _assetRepository.IsExistingCode(model.Id, model.Code))
            {
                return Result.Fail(Constant.Message.CODE_IS_EXISTS);
            }

            var validation = await new UpdateAssetModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _assetFactory.Update(model);

            await _assetRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(AssetModel model)
        {
            if (await _assetRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
