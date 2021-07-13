using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class ReligionService : IReligionService
    {
        private readonly IReligionRepository _religionRepository;

        public ReligionService(
            IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
        }
    }
}
