using System;
using HRM.Domain.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public interface IProfessionalQualificationFactory
    {
        ProfessionalQualification Create(ProfessionalQualificationModel model);

        ProfessionalQualification Update(ProfessionalQualificationModel model);
    }
}
