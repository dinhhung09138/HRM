using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class ModelOfStudyService : IModelOfStudyService
    {
        private readonly IModelOfStudyRepository _modelOfStudyRepository;

        public ModelOfStudyService(
            IModelOfStudyRepository modelOfStudyRepository)
        {
            _modelOfStudyRepository = modelOfStudyRepository;
        }
    }
}
