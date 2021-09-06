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
    public sealed class AssetContractDetailService : IAssetContractDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssetContractDetailFactory _assetContractDetailFactory;
        private readonly IAssetContractDetailRepository _assetContractDetailRepository;

        public AssetContractDetailService(
            IUnitOfWork unitOfWork,
            IAssetContractDetailFactory assetContractDetailFactory,
            IAssetContractDetailRepository assetContractDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _assetContractDetailFactory = assetContractDetailFactory;
            _assetContractDetailRepository = assetContractDetailRepository;
        }

        public async Task<IResult<AssetContractDetailModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _assetContractDetailRepository.FindByIdAsync(id);

                return Result<AssetContractDetailModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<AssetContractDetailModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult> SaveAsync(AssetContractDetailModel model)
        {
            try
            {
                return await Create(model);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(AssetContractDetailModel model)
        {
            try
            {
                var md = await _assetContractDetailRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                await _assetContractDetailRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(AssetContractDetailModel model)
        {
            var md = _assetContractDetailFactory.Create(model);

            await _assetContractDetailRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
