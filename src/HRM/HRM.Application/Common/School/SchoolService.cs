using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(
            ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
    }
}
