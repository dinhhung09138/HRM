using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class CertificatedService : ICertificatedService
    {
        private readonly ICertificatedRepository _certificatedRepository;

        public CertificatedService(
            ICertificatedRepository certificatedRepository)
        {
            _certificatedRepository = certificatedRepository;
        }
    }
}
