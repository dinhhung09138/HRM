using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class NationalityService : INationalityService
    {
        private readonly INationalityRepository _nationalityRepository;

        public NationalityService(
            INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }
    }
}
