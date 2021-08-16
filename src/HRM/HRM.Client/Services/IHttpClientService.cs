using HRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Client.Services
{
    public interface IHttpClientService
    {
        Task<T> Get<T>(string url);

        Task<TResponse> Get<T, TResponse>(string url);

        Task<TResponse> Post<T, TResponse>(string url, T model);

        Task<TResponse> Put<T, TResponse>(string url, T model);

        Task<TResponse> Delete<T, TResponse>(string url);
    }
}
