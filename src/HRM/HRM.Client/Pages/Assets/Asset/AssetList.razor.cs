using System;
using System.Linq;
using HRM.Model.Assets;
using HRM.Client.Models;
using HRM.Infrastructure;
using DotNetCore.Objects;
using HRM.Client.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using AntDesign;
using HRM.Model;
using HRM.Client.Helpers;

namespace HRM.Client.Pages.Assets.Asset
{
    partial class AssetList :ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientService httpClientService { get; set; }

        [Inject]
        public SelectboxDataHelper selectboxDataHelper { get; set; }

        [CascadingParameter(Name = "Bredcrumb")]
        public List<BreadcurmbModel> Breadcrumb { get; set; } = new List<BreadcurmbModel>();

        private bool tableLoading = true;
        private List<AssetGridModel> listData = new List<AssetGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private AssetGridParameterModel parameterModel = new AssetGridParameterModel();

        private AssetGridModel deletedItem = new AssetGridModel();
        private bool isVisibleDeleteModel = false;

        private List<BaseSelectboxModel> assetTypeList = new List<BaseSelectboxModel>();

        protected async override Task OnInitializedAsync()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Quản lý tài sản",
                Href = "asset",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Danh sách tài sản",
                IsActive = true,
            });

            await LoadAssetTypeDropdown();
            await LoadGridData();
        }

        protected async Task SearchClick()
        {
            await LoadGridData();
        }

        protected async Task PageChange(PaginationEventArgs args)
        {
            if (totalItems == 0)
            {
                return;
            }
            parameterModel.Page = new Page() { Index = args.Page, Size = args.PageSize };
            await LoadGridData();
        }

        protected void AddNewClick()
        {
            navigationManager.NavigateTo("asset/create");
        }

        protected void UpdateClick(AssetGridModel item)
        {
            navigationManager.NavigateTo($"asset/update/{item.Id}");
        }

        protected void DeleteClick(AssetGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<AssetModel, HttpActionResponseWrapper>($"asset/{deletedItem.Id}");
            if (result.Succeeded)
            {
                await toastMessageHelper.DeleteSuccess();

                if (listData.Count == 1)
                {
                    parameterModel.Page.Index = 1;
                }

                await LoadGridData();
            }
            else
            {
                await toastMessageHelper.DeleteError();
            }
            isVisibleDeleteModel = false;
            deletedItem = null;
        }

        private async Task LoadGridData()
        {
            tableLoading = true;

            var result = await httpClientService.Post<AssetGridParameterModel, HttpDataResponseWrapper<Model.Grid<AssetGridModel>>>("asset/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<AssetGridModel>();
                totalItems = (int)result.Data.Count;
                tableLoading = false;
            }
            StateHasChanged();
        }

        private async Task LoadAssetTypeDropdown()
        {
            assetTypeList = await selectboxDataHelper.GetAssetType();
        }
    }
}
