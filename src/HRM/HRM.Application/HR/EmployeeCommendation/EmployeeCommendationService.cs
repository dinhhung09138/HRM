using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeCommendationService : IEmployeeCommendationService
    {
        private readonly IEmployeeCommendationRepository _employeeCommendationRepository;

        public EmployeeCommendationService(
            IEmployeeCommendationRepository employeeCommendationRepository)
        {
            _employeeCommendationRepository = employeeCommendationRepository;
        }
    }
}
