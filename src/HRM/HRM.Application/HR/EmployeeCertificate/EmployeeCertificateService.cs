using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class EmployeeCertificateService : IEmployeeCertificateService
    {
        private readonly IEmployeeCertificateRepository _employeeCertificateRepository;

        public EmployeeCertificateService(
            IEmployeeCertificateRepository employeeCertificateRepository)
        {
            _employeeCertificateRepository = employeeCertificateRepository;
        }
    }
}
