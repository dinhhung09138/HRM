using System.Threading.Tasks;

namespace HRM.Database
{
    public interface IUnitOfWork
    {
        Task BeginTranactionAsync();

        Task RollBackAsync();

        Task CommitAsync();

        Task SaveChangesAsync();
    }
}
