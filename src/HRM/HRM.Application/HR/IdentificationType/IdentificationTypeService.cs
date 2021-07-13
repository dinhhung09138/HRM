using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class IdentificationTypeService : IIdentificationTypeService
    {
        private readonly IIdentificationTypeRepository _identificationTypeRepository;

        public IdentificationTypeService(
            IIdentificationTypeRepository identificationTypeRepository)
        {
            _identificationTypeRepository = identificationTypeRepository;
        }
    }
}
