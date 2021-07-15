using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM.Database.HR
{
    public sealed class EmployeeEducationRepository : EFRepository<EmployeeEducation>, IEmployeeEducationRepository
    {
        public EmployeeEducationRepository(Context context) : base(context) { }
    }
}
