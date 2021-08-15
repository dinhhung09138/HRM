using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using HRM.Model;
using HRM.Client.Models;
using Newtonsoft.Json;
using HRM.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace HRM.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private string _baseApiUrl = string.Empty;

        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        //private readonly Task<Setting> _settingTask;

        private readonly JsonSerializerOptions _defaultJsonOption;
        private readonly ToastMessageHelper _toastMessageHelper;

        public HttpClientService(
            IConfiguration config,
            HttpClient httpClient,
            //Task<Setting> settingTask,
            ToastMessageHelper toastMessageHelper)
        {
            _config = config;
            _httpClient = httpClient;
            //_settingTask = settingTask;
            _toastMessageHelper = toastMessageHelper;
            _defaultJsonOption = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            _baseApiUrl = _config.GetSection("AppSettings")["ApiUrl"];

        }

        public async Task<T> GetT<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync($"{_baseApiUrl}{url}");

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(httpResponse, _defaultJsonOption);
                return response;
            }
            else
            {
                await _toastMessageHelper.ApplicationError(httpResponse.StatusCode);
            }
            return default;
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<T>(content);


                var responseStream = await httpResponse.Content.ReadAsStringAsync();

                var result1 = System.Text.Json.JsonSerializer.Deserialize<T>(responseStream, _defaultJsonOption);

                var data = await Deserialize<T>(httpResponse, _defaultJsonOption);
                var response = new HttpResponseWrapper<T>(data, true, httpResponse);
                return response;
            }
            return new HttpResponseWrapper<T>(default, false, httpResponse);
        }

        public Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> Delete(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            throw new NotImplementedException();
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            try
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
                return result;
            }
            catch (Exception ex)
            {

            }
            return default;
        }
    }
}
