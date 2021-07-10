using Microsoft.EntityFrameworkCore;

namespace HRM.Database.Context
{
    public sealed class ContextFactory
    {
        public Context CreateDbContext(string[] arg)
        {
            const string connectionString = "Data Source=.Trim\\SqlExpress;Inital Catalog=HRM;Trusted_Connection=True;MultipleActiveResultSets=True;";
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
        }
    }
}
