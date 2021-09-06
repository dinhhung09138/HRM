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

namespace HRM.Client.Pages.Assets.Contract
{
    partial class ContractList : ComponentBase
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
        private List<AssetContractGridModel> listData = new List<AssetContractGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private AssetContractGridParameterModel parameterModel = new AssetContractGridParameterModel();

        private AssetContractGridModel deletedItem = new AssetContractGridModel();
        private bool isVisibleDeleteModel = false;

        private List<BaseSelectboxModel> vendorList = new List<BaseSelectboxModel>();

        protected async override Task OnInitializedAsync()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Tài sản",
                Href = "asset",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Hợp đồng",
                IsActive = true,
            });

            await LoadVendorDropdown();
            //await LoadGridData();
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
            navigationManager.NavigateTo("asset/contract/create");
        }

        protected void UpdateClick(AssetContractGridModel item)
        {
            navigationManager.NavigateTo($"asset/contract/update/{item.Id}");
        }

        protected void DeleteClick(AssetContractGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<AssetContractModel, HttpActionResponseWrapper>($"asset-contract/{deletedItem.Id}");
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
                await toastMessageHelper.Error(result.Message);
            }
            isVisibleDeleteModel = false;
            deletedItem = null;
        }

        private async Task LoadGridData()
        {
            tableLoading = true;

            var result = await httpClientService.Post<AssetContractGridParameterModel, HttpDataResponseWrapper<Model.Grid<AssetContractGridModel>>>("asset-contract/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<AssetContractGridModel>();
                totalItems = (int)result.Data.Count;
                tableLoading = false;
            }
            StateHasChanged();
        }

        private async Task LoadVendorDropdown()
        {
            vendorList = await selectboxDataHelper.GetVendor();
            StateHasChanged();
        }

    }
}
