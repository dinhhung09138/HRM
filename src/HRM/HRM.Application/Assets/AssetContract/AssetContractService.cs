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
    public sealed class AssetContractService : IAssetContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssetContractFactory _assetContractFactory;
        private readonly IAssetContractRepository _assetContractRepository;
        private readonly IAssetContractDetailFactory _assetContractDetailFactory;
        private readonly IAssetContractDetailRepository _assetContractDetailRepository;

        public AssetContractService(
            IUnitOfWork unitOfWork,
            IAssetContractFactory assetContractFactory,
            IAssetContractRepository assetContractRepository,
            IAssetContractDetailFactory assetContractDetailFactory,
            IAssetContractDetailRepository assetContractDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _assetContractFactory = assetContractFactory;
            _assetContractRepository = assetContractRepository;
            _assetContractDetailFactory = assetContractDetailFactory;
            _assetContractDetailRepository = assetContractDetailRepository;
        }

        public async Task<IResult<AssetContractModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _assetContractRepository.FindByIdAsync(id);

                return Result<AssetContractModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<AssetContractModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<AssetContractGridModel>>> GridAsync(AssetContractGridParameterModel paramters)
        {
            try
            {
                var grid = await _assetContractRepository.GridAsync(paramters);
                return Result<Grid<AssetContractGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(AssetContractModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(AssetContractModel model)
        {
            try
            {
                var md = await _assetContractRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _assetContractRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(AssetContractModel model)
        {
            var validation = await new CreateAssetContractModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _assetContractFactory.Create(model);

            await _assetContractRepository.SaveAsync(md, true);

            foreach (var detail in model.Details)
            {
                validation = await new CreateAssetContractDetailModelValidator().ValidateAsync(detail);

                if (validation.IsValid == false)
                {
                    return Result.Fail(validation.Errors.GetErrorMessage());
                }

                var dt = _assetContractDetailFactory.Create(detail);
                await _assetContractDetailRepository.SaveAsync(dt, true);
            }

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(AssetContractModel model)
        {
            var md = await _assetContractRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateAssetContractModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _assetContractFactory.Update(model);

            await _assetContractRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
