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
    public class ContractTypeService : IContractTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContractTypeFactory _contractTypeFactory;
        private readonly IContractTypeRepository _contractTypeRepository;

        public ContractTypeService(
            IUnitOfWork unitOfWork,
            IContractTypeFactory contractTypeFactory,
            IContractTypeRepository contractTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _contractTypeFactory = contractTypeFactory;
            _contractTypeRepository = contractTypeRepository;
        }

        public async Task<IResult<ContractTypeModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _contractTypeRepository.FindByIdAsync(id);

                return Result<ContractTypeModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<ContractTypeModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<ContractTypeGridModel>>> GridAsync(ContractTypeGridParameterModel paramters)
        {
            try
            {
                var grid = await _contractTypeRepository.GridAsync(paramters);
                return Result<Grid<ContractTypeGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<List<BaseSelectboxModel>>> DropdownAsync()
        {
            var data = await _contractTypeRepository.DropdownAsync();
            return Result<List<BaseSelectboxModel>>.Success(data);
        }

        public async Task<IResult> SaveAsync(ContractTypeModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(ContractTypeModel model)
        {
            try
            {
                var md = await _contractTypeRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _contractTypeRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(ContractTypeModel model)
        {
            var validation = await new CreateContractTypeModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            if (await _contractTypeRepository.IsExistingCode(model.Id, model.Code))
            {
                return Result.Fail(Constant.Message.CODE_IS_EXISTS);
            }

            var md = _contractTypeFactory.Create(model);

            await _contractTypeRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(ContractTypeModel model)
        {
            var md = await _contractTypeRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var checkCurrentVersionResponse = await CheckCurrentVersion(model);
            if (checkCurrentVersionResponse.Succeeded == false)
            {
                return checkCurrentVersionResponse;
            }

            if (await _contractTypeRepository.IsExistingCode(model.Id, model.Code))
            {
                return Result.Fail(Constant.Message.CODE_IS_EXISTS);
            }

            var validation = await new UpdateContractTypeModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _contractTypeFactory.Update(model);

            await _contractTypeRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> CheckCurrentVersion(ContractTypeModel model)
        {
            if (await _contractTypeRepository.IsCurrentVersion(model.Id, model.RowVersion) == false)
            {
                return Result.Fail(Constant.Message.DATA_IS_NOT_CURRENT_VERSION);
            }
            return Result.Success();
        }
    }
}
