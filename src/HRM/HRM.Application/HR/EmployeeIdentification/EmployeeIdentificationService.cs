using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeIdentificationService : IEmployeeIdentificationService
    {
        private readonly IEmployeeIdentificationRepository _employeeIdentificationRepository;

        public EmployeeIdentificationService(
            IEmployeeIdentificationRepository employeeIdentificationRepository)
        {
            _employeeIdentificationRepository = employeeIdentificationRepository;
        }
    }
}
