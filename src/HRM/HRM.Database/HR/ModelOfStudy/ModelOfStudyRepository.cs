using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.HR;
using HRM.Domain.HR;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM.Database.HR
{
    public sealed class ModelOfStudyRepository : EFRepository<ModelOfStudy>, IModelOfStudyRepository
    {
        public ModelOfStudyRepository(Context context) : base(context) { }
    }
}
