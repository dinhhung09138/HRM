using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EthnicityService : IEthnicityService
    {
        private readonly IEthnicityRepository _ethnicityRepository;

        public EthnicityService(
            IEthnicityRepository ethnicityRepository)
        {
            _ethnicityRepository = ethnicityRepository;
        }
    }
}
