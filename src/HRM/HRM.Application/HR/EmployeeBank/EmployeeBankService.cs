using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeBankService : IEmployeeBankService
    {
        private readonly IEmployeeBankRepository _employeeBankRepository;

        public EmployeeBankService(
            IEmployeeBankRepository employeeBankRepository)
        {
            _employeeBankRepository = employeeBankRepository;
        }
    }
}
