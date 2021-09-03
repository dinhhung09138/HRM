using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Constant.Enums;
using HRM.Infrastructure.Extension;
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
            listData.Add(new BaseSelectboxModel() { Id = "", Name = "Phân loại" });
            if (response.Succeeded)
            {
                listData.AddRange(response.Data);
            }

            return listData;
        }

        public async Task<List<BaseSelectboxModel>> GetVendor()
        {
            //var response = await _httpClientService.Get<HttpDataResponseWrapper<List<BaseSelectboxModel>>>($"asset-type/dropdown");
            List<BaseSelectboxModel> listData = new List<BaseSelectboxModel>();
            listData.Add(new BaseSelectboxModel() { Id = "", Name = "Đơn vị phân phối" });
            listData.Add(new BaseSelectboxModel() { Id = "1", Name = "Hung" });
            //if (response.Succeeded)
            //{
            //    listData.AddRange(response.Data);
            //}

            return listData;
        }

        public List<BaseSelectboxModel> GetAssetStatus()
        {
            List<BaseSelectboxModel> listData = new List<BaseSelectboxModel>();
            listData.Add(new BaseSelectboxModel() { Id = "", Name = "Trạng thái" });
            listData.Add(new BaseSelectboxModel() { Id = AssetStatus.Good.ToString(), Name = AssetStatus.Good.GetEnumDescription() });
            listData.Add(new BaseSelectboxModel() { Id = AssetStatus.Broken.ToString(), Name = AssetStatus.Broken.GetEnumDescription() });
            listData.Add(new BaseSelectboxModel() { Id = AssetStatus.Liquidation.ToString(), Name = AssetStatus.Liquidation.GetEnumDescription() });
            
            return listData;
        }
    }
}
