

namespace HRM.Infrastructure.Services
{
    public interface IMemoryCaching
    {
        void Add<T>(string key, T data);

        T GetFromCache<T>(string key);

        void RemoveFromCache(string key);
    }
}
