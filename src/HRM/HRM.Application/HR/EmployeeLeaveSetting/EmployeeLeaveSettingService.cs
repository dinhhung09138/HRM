using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeLeaveSettingService : IEmployeeLeaveSettingService
    {
        private readonly IEmployeeLeaveSettingRepository _employeeLeaveSettingRepository;

        public EmployeeLeaveSettingService(
            IEmployeeLeaveSettingRepository employeeLeaveSettingRepository)
        {
            _employeeLeaveSettingRepository = employeeLeaveSettingRepository;
        }
    }
}
