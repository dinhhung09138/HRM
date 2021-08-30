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
    public sealed class AssetTypeService : IAssetTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssetTypeFactory _assetTypeFactory;
        private readonly IAssetTypeRepository _assetTypeRepository;

        public AssetTypeService(
            IUnitOfWork unitOfWork,
            IAssetTypeFactory assetTypeFactory,
            IAssetTypeRepository assetTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _assetTypeFactory = assetTypeFactory;
            _assetTypeRepository = assetTypeRepository;
        }

        public async Task<IResult<AssetTypeModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _assetTypeRepository.FindByIdAsync(id);

                return Result<AssetTypeModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<AssetTypeModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<AssetTypeGridModel>>> GridAsync(AssetTypeGridParameterModel paramters)
        {
            try
            {
                var grid = await _assetTypeRepository.GridAsync(paramters);
                return Result<Grid<AssetTypeGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(AssetTypeModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(AssetTypeModel model)
        {
            try
            {
                var md = await _assetTypeRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _assetTypeRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(AssetTypeModel model)
        {
            var validation = await new CreateAssetTypeModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _assetTypeFactory.Create(model);

            await _assetTypeRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(AssetTypeModel model)
        {
            var md = await _assetTypeRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateAssetTypeModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _assetTypeFactory.Update(model);

            await _assetTypeRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
