using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Text.Json;
using HRM.Model;
using HRM.Client.Models;
using HRM.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Text;
using Newtonsoft.Json;

namespace HRM.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private string _baseApiUrl = string.Empty;

        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings _defaultJsonOption;
        private readonly ToastMessageHelper _toastMessageHelper;

        public HttpClientService(
            IConfiguration config,
            HttpClient httpClient,
            ToastMessageHelper toastMessageHelper)
        {
            _config = config;
            _httpClient = httpClient;
            _toastMessageHelper = toastMessageHelper;
            _defaultJsonOption = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameHandling = TypeNameHandling.All,
                StringEscapeHandling = StringEscapeHandling.Default,
            };

            _baseApiUrl = _config.GetSection("AppSettings")["ApiUrl"];

        }

        public async Task<T> Get<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync($"{_baseApiUrl}{url}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await Deserialize<T>(httpResponse, _defaultJsonOption);
            }
            else
            {
                await _toastMessageHelper.ApplicationError(httpResponse.StatusCode);
            }
            return default;
        }

        public async Task<TResponse> Get<T, TResponse>(string url)
        {
            var httpResponse = await _httpClient.GetAsync($"{_baseApiUrl}{url}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await Deserialize<TResponse>(httpResponse, _defaultJsonOption);
            }
            else
            {
                await _toastMessageHelper.ApplicationError(httpResponse.StatusCode);
            }
            return default;
        }

        public async Task<TResponse> Post<T, TResponse>(string url, T model)
        {
            var dataJson = JsonConvert.SerializeObject(model);

            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync($"{_baseApiUrl}{url}", stringContent);

            if (httpResponse.IsSuccessStatusCode)
            {
                return await Deserialize<TResponse>(httpResponse, _defaultJsonOption);
            }
            else
            {
                await _toastMessageHelper.ApplicationError(httpResponse.StatusCode);
            }
            return default;
        }

        public async Task<TResponse> Put<T, TResponse>(string url, T model)
        {
            var dataJson = JsonConvert.SerializeObject(model);

            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PutAsync($"{_baseApiUrl}{url}", stringContent);

            if (httpResponse.IsSuccessStatusCode)
            {
                return await Deserialize<TResponse>(httpResponse, _defaultJsonOption);
            }
            else
            {
                await _toastMessageHelper.ApplicationError(httpResponse.StatusCode);
            }
            return default;
        }

        public async Task<TResponse> Delete<T, TResponse>(string url)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{_baseApiUrl}{url}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await Deserialize<TResponse>(httpResponse, _defaultJsonOption);
            }
            else
            {
                await _toastMessageHelper.ApplicationError(httpResponse.StatusCode);
            }
            return default;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerSettings options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(responseString);
            return response;
        }

    }
}
