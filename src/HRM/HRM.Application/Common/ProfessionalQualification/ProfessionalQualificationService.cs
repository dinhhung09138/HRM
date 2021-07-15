using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class ProfessionalQualificationService : IProfessionalQualificationService
    {
        private readonly IProfessionalQualificationRepository _professionalQualificationRepository;

        public ProfessionalQualificationService(
            IProfessionalQualificationRepository professionalQualificationRepository)
        {
            _professionalQualificationRepository = professionalQualificationRepository;
        }
    }
}
