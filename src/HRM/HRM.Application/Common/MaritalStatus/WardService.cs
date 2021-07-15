using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class WardService : IWardService
    {
        private readonly IWardRepository _wardRepository;

        public WardService(
            IWardRepository wardRepository)
        {
            _wardRepository = wardRepository;
        }
    }
}
