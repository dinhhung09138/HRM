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
using System.Net.Http.Headers;
using Microsoft.JSInterop;
using HRM.Infrastructure.Extension;
using HRM.Model.System;

namespace HRM.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private string _baseApiUrl = string.Empty;

        private readonly IJSRuntime _jsRuntime;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly IClientStorageService _localStorage;

        private readonly JsonSerializerSettings _defaultJsonOption;
        private readonly ToastMessageHelper _toastMessageHelper;

        public HttpClientService(
            IConfiguration config,
            IJSRuntime jsRuntime,
            HttpClient httpClient,
            IClientStorageService localStorage,
            ToastMessageHelper toastMessageHelper)
        {
            _config = config;
            _jsRuntime = jsRuntime;
            _httpClient = httpClient;
            _localStorage = localStorage;
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

        private async Task<HttpRequestMessage> CreateHeaderRequest(string url, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, url);

            var token = await _localStorage.GetItem<TokenModel>(Constant.ConstantKey.TOKEN_STORAGE_KEY);

            if (token != null && !string.IsNullOrEmpty(token.Token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            }

            return request;
        }

        public async Task<T> Get<T>(string url)
        {
            var request = await CreateHeaderRequest($"{_baseApiUrl}{url}", HttpMethod.Get);

            var httpResponse = await _httpClient.SendAsync(request);

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
            var request = await CreateHeaderRequest($"{_baseApiUrl}{url}", HttpMethod.Get);

            var httpResponse = await _httpClient.SendAsync(request);

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

            var request = await CreateHeaderRequest($"{_baseApiUrl}{url}", HttpMethod.Post);
            request.Content = stringContent;

            var httpResponse = await _httpClient.SendAsync(request);

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

            var request = await CreateHeaderRequest($"{_baseApiUrl}{url}", HttpMethod.Put);
            request.Content = stringContent;

            var httpResponse = await _httpClient.SendAsync(request);

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
            var request = await CreateHeaderRequest($"{_baseApiUrl}{url}", HttpMethod.Delete);

            var httpResponse = await _httpClient.SendAsync(request);

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
