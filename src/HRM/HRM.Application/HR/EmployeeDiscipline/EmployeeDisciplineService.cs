using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeDisciplineService : IEmployeeDisciplineService
    {
        private readonly IEmployeeDisciplineRepository _employeeDisciplineRepository;

        public EmployeeDisciplineService(
            IEmployeeDisciplineRepository employeeDisciplineRepository)
        {
            _employeeDisciplineRepository = employeeDisciplineRepository;
        }
    }
}
