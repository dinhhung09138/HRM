using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class ApproveStatusService : IApproveStatusService
    {
        private readonly IApproveStatusRepository _approveStatusRepository;

        public ApproveStatusService(
            IApproveStatusRepository approveStatusRepository)
        {
            _approveStatusRepository = approveStatusRepository;
        }
    }
}
