using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Client.Helpers
{
    public class SelectboxDataHelper
    {
        private IHttpClientService _httpClientService;

        public SelectboxDataHelper(
            IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<BaseSelectboxModel>> GetAssetType()
        {
            var response = await _httpClientService.Get<HttpDataResponseWrapper<List<BaseSelectboxModel>>>($"asset-type/dropdown");
            List<BaseSelectboxModel> listData = new List<BaseSelectboxModel>();
            if (response.Succeeded)
            {
                listData = response.Data;
            }

            return listData;
        }
    }
}
