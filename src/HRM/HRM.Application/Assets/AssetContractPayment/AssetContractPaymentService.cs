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
    public sealed class AssetContractPaymentService : IAssetContractPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssetContractPaymentFactory _assetContractPaymentFactory;
        private readonly IAssetContractPaymentRepository _assetContractPaymentRepository;

        public AssetContractPaymentService(
            IUnitOfWork unitOfWork,
            IAssetContractPaymentFactory assetContractPaymentFactory,
            IAssetContractPaymentRepository assetContractPaymentRepository)
        {
            _unitOfWork = unitOfWork;
            _assetContractPaymentFactory = assetContractPaymentFactory;
            _assetContractPaymentRepository = assetContractPaymentRepository;
        }

        public async Task<IResult<AssetContractPaymentModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _assetContractPaymentRepository.FindByIdAsync(id);

                return Result<AssetContractPaymentModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<AssetContractPaymentModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<AssetContractPaymentGridModel>>> GridAsync(AssetContractPaymentGridParameterModel paramters)
        {
            try
            {
                var grid = await _assetContractPaymentRepository.GridAsync(paramters);
                return Result<Grid<AssetContractPaymentGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(AssetContractPaymentModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(AssetContractPaymentModel model)
        {
            try
            {
                var md = await _assetContractPaymentRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _assetContractPaymentRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(AssetContractPaymentModel model)
        {
            var validation = await new CreateAssetContractPaymentModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _assetContractPaymentFactory.Create(model);

            await _assetContractPaymentRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(AssetContractPaymentModel model)
        {
            var md = await _assetContractPaymentRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateAssetContractPaymentModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _assetContractPaymentFactory.Update(model);

            await _assetContractPaymentRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
