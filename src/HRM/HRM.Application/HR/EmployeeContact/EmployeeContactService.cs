using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeContactService : IEmployeeContactService
    {
        private readonly IEmployeeContactRepository _employeeContactRepository;

        public EmployeeContactService(
            IEmployeeContactRepository employeeContactRepository)
        {
            _employeeContactRepository = employeeContactRepository;
        }
    }
}
