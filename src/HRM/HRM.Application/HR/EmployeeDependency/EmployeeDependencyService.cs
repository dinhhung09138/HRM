using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeDependencyService : IEmployeeDependencyService
    {
        private readonly IEmployeeDependencyRepository _employeeDependencyRepository;

        public EmployeeDependencyService(
            IEmployeeDependencyRepository employeeDependencyRepository)
        {
            _employeeDependencyRepository = employeeDependencyRepository;
        }
    }
}
