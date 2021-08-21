using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Newtonsoft.Json;

namespace HRM.Client.Services
{
    public class ClientStorageService : IClientStorageService
    {
        private readonly ILocalStorageService _localStorage;
        
        public ClientStorageService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SetItem(string key, string data)
        {
            await RemoveItem(key);

            await _localStorage.SetItemAsStringAsync(key, data);
        }

        public async Task<string> GetItem(string key)
        {
            return await _localStorage.GetItemAsStringAsync(key);
        }

        public async Task RemoveItem(string key)
        {
            await _localStorage.RemoveItemAsync(key);
        }

    }
}
