using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeEducationService : IEmployeeEducationService
    {
        private readonly IEmployeeEducationRepository _employeeEducationRepository;

        public EmployeeEducationService(
            IEmployeeEducationRepository employeeEducationRepository)
        {
            _employeeEducationRepository = employeeEducationRepository;
        }
    }
}
