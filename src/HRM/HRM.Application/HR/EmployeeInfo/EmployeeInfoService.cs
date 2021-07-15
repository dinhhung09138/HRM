﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private readonly IEmployeeInfoRepository _employeeInfoRepository;

        public EmployeeInfoService(
            IEmployeeInfoRepository employeeInfoRepository)
        {
            _employeeInfoRepository = employeeInfoRepository;
        }
    }
}
