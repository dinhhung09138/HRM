using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HRM.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] arg)
        {
            const string connectionString = "Data Source=STS-HUNGTRAN\\SQLEXPRESS;Initial Catalog=HRM;User Id=sa;Password=hung764119;";
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
        }
    }
}
