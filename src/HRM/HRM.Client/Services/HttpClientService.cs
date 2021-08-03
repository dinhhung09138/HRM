using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.Model;

namespace HRM.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseModel> Get(string url)
        {
            ResponseModel md = new ResponseModel();

            return md;
        }
    }
}
