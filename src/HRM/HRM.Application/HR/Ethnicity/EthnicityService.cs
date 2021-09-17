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
    public class EthnicityService : IEthnicityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEthnicityFactory _ethnicityFactory;
        private readonly IEthnicityRepository _ethnicityRepository;

        public EthnicityService(
            IUnitOfWork unitOfWork,
            IEthnicityFactory ethnicityFactory,
            IEthnicityRepository ethnicityRepository)
        {
            _unitOfWork = unitOfWork;
            _ethnicityFactory = ethnicityFactory;
            _ethnicityRepository = ethnicityRepository;
        }

        public async Task<IResult<EthnicityModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _ethnicityRepository.FindByIdAsync(id);

                return Result<EthnicityModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<EthnicityModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<EthnicityGridModel>>> GridAsync(EthnicityGridParameterModel paramters)
        {
            try
            {
                var grid = await _ethnicityRepository.GridAsync(paramters);
                return Result<Grid<EthnicityGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _ethnicityRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(EthnicityModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(EthnicityModel model)
        {
            try
            {
                var md = await _ethnicityRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _ethnicityRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(EthnicityModel model)
        {
            var validation = await new CreateEthnicityModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _ethnicityFactory.Create(model);

            await _ethnicityRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(EthnicityModel model)
        {
            var md = await _ethnicityRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            var validation = await new UpdateEthnicityModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _ethnicityFactory.Update(model);

            await _ethnicityRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(EthnicityModel model)
        {
            if (await _ethnicityRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
