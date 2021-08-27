using System;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.Repositories;
using HRM.Model;

namespace HRM.Database.Common
{
    public interface IProfessionalQualificationRepository : IRepository<ProfessionalQualification>
    {
        Task<ProfessionalQualificationModel> FindByIdAsync(long id);

        Task<Grid<ProfessionalQualificationGridModel>> GridAsync(ProfessionalQualificationGridParameterModel paramters);

        Task<bool> SaveAsync(ProfessionalQualification model, bool isCreate);

        Task<bool> DeleteAsync(ProfessionalQualification model);
    }
}
