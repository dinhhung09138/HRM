using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(
            IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
    }
}
