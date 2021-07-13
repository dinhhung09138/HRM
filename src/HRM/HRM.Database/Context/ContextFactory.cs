using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HRM.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] arg)
        {
            const string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=HRM;Trusted_Connection=True;MultipleActiveResultSets=True;";
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
        }
    }
}
