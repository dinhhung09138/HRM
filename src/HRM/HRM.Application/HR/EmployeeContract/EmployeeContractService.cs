using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeContractService : IEmployeeContractService
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;

        public EmployeeContractService(
            IEmployeeContractRepository employeeContractRepository)
        {
            _employeeContractRepository = employeeContractRepository;
        }
    }
}
