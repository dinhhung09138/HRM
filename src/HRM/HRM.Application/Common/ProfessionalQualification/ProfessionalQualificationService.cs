using System;
using System.Linq;
using HRM.Database.Common;
using HRM.Model;
using HRM.Model.Common;
using HRM.Database;
using System.Threading.Tasks;
using DotNetCore.Results;
using HRM.Infrastructure.Extension;
using HRM.Infrastructure.Services;

namespace HRM.Application.Common
{
    public class ProfessionalQualificationService : IProfessionalQualificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCaching _memoryCache;
        private readonly IProfessionalQualificationFactory _professionalQualificationFactory;
        private readonly IProfessionalQualificationRepository _professionalQualificationRepository;

        public ProfessionalQualificationService(
            IUnitOfWork unitOfWork,
            IMemoryCaching memoryCache,
            IProfessionalQualificationFactory professionalQualificationFactory,
            IProfessionalQualificationRepository professionalQualificationRepository)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _professionalQualificationFactory = professionalQualificationFactory;
            _professionalQualificationRepository = professionalQualificationRepository;
        }

        public async Task<IResult<ProfessionalQualificationModel>> FindByIdAsync(long id)
        {
            try
            {
                var item = await _professionalQualificationRepository.FindByIdAsync(id);

                return Result<ProfessionalQualificationModel>.Success(item);
            }
            catch (Exception ex)
            {
                return Result<ProfessionalQualificationModel>.Fail(ex.Message);
            }
        }

        public async Task<IResult<Grid<ProfessionalQualificationGridModel>>> GridAsync(ProfessionalQualificationGridParameterModel paramters)
        {
            try
            {
                var grid = await _professionalQualificationRepository.GridAsync(paramters);
                return Result<Grid<ProfessionalQualificationGridModel>>.Success(grid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult> SaveAsync(ProfessionalQualificationModel model, bool isCreate)
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

        public async Task<IResult> DeleteAsync(ProfessionalQualificationModel model)
        {
            try
            {
                var md = await _professionalQualificationRepository.GetAsync(model.Id);

                if (md == null)
                {
                    return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
                }

                md.Deleted = true;
                md.UpdateBy = model.UpdateBy;
                md.UpdateDate = DateTime.Now;

                await _professionalQualificationRepository.DeleteAsync(md);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<IResult> Create(ProfessionalQualificationModel model)
        {
            var validation = await new CreateProfessionalQualificationModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var md = _professionalQualificationFactory.Create(model);

            await _professionalQualificationRepository.SaveAsync(md, true);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private async Task<IResult> Update(ProfessionalQualificationModel model)
        {
            var md = await _professionalQualificationRepository.GetAsync(model.Id);

            if (md == null)
            {
                return Result.Fail(Constant.Message.WARNING_ITEM_NOT_FOUND);
            }

            var validation = await new UpdateProfessionalQualificationModelValidator().ValidateAsync(model);
            if (validation.IsValid == false)
            {
                return Result.Fail(validation.Errors.GetErrorMessage());
            }

            var item = _professionalQualificationFactory.Update(model);

            await _professionalQualificationRepository.SaveAsync(item, false);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
