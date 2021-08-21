using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Client.Services
{
    public interface IClientStorageService
    {
        Task<string> GetItem(string key);

        Task SetItem(string key, string data);

        Task RemoveItem(string key);
    }
}
