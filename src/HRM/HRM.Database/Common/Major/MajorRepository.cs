using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Common;
using HRM.Domain.Common;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM.Database.Common
{
    public sealed class MajorRepository : EFRepository<Major>, IMajorRepository
    {
        public MajorRepository(Context context) : base(context) { }
    }
}
