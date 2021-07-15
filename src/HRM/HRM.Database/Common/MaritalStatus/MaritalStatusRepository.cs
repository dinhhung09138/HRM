using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM.Database.Common
{
    public class MaritalStatusRepository : EFRepository<MaritalStatus>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(Context context) : base(context) { }
    }
}
