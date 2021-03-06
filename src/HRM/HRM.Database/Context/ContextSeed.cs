using Microsoft.EntityFrameworkCore;
using HRM.Database.HR;
using HRM.Database.System;

namespace HRM.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedBranchs();
            builder.SeedEmployees();
            builder.SeedSystemUsers();
            builder.SeedReligions();
            builder.SeedRelationshipTypes();
            builder.SeedRankings();
            builder.SeedNationalitys();
            builder.SeedModelOfStudys();
            builder.SeedLeaveTypes();
            builder.SeedContractTypes();
            builder.SeedEthnicitys();
        }
    }
}
