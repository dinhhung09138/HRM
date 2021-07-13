using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeWorkingStatusService : IEmployeeWorkingStatusService
    {
        private readonly IEmployeeWorkingStatusRepository _employeeWorkingStatusRepository;

        public EmployeeWorkingStatusService(
            IEmployeeWorkingStatusRepository employeeWorkingStatusRepository)
        {
            _employeeWorkingStatusRepository = employeeWorkingStatusRepository;
        }
    }
}
