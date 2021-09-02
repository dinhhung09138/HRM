using System;
using System.Linq;
using HRM.Components;
using HRM.Model.Assets;
using HRM.Client.Models;
using HRM.Constant.Enums;
using HRM.Infrastructure;
using DotNetCore.Objects;
using HRM.Client.Services;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using HRM.Infrastructure.Extension;
using Microsoft.AspNetCore.Components;
using AntDesign;
using HRM.Client.Helpers;

namespace HRM.Client.Pages.Assets.Type
{
    partial class TypeList : ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientService httpClientService { get; set; }

        public TypeList()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Tài sản",
                Href = "asset",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Loại tài sản",
                IsActive = true,
            });
        }

        [CascadingParameter(Name = "Bredcrumb")]
        public List<BreadcurmbModel> Breadcrumb { get; set; } = new List<BreadcurmbModel>();

        private bool tableLoading = true;
        private List<AssetTypeGridModel> listData = new List<AssetTypeGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private AssetTypeGridParameterModel parameterModel = new AssetTypeGridParameterModel();

        private AssetTypeGridModel deletedItem = new AssetTypeGridModel();
        private bool isVisibleDeleteModel = false;

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
                Title = "Loại tài sản",
                IsActive = true,
            });
            await LoadGridData();
        }

        private async Task SearchClick()
        {
            await LoadGridData();
        }

        protected async Task PageChange(PaginationEventArgs args)
        {
            parameterModel.Page = new Page() { Index = args.Page, Size = args.PageSize };
            await LoadGridData();
        }

        private void AddNewClick()
        {
            navigationManager.NavigateTo("asset/type/create");
        }

        private void UpdateClick(AssetTypeGridModel item)
        {
            navigationManager.NavigateTo($"asset/type/update/{item.Id}");
        }

        private void DeleteClick(AssetTypeGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        private async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<AssetTypeModel, HttpActionResponseWrapper>($"asset-type/{deletedItem.Id}");
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
            
            var result = await httpClientService.Post<AssetTypeGridParameterModel, HttpDataResponseWrapper<Model.Grid<AssetTypeGridModel>>>("asset-type/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<AssetTypeGridModel>();
                totalItems = (int)result.Data.Count;
                tableLoading = false;
                StateHasChanged();
            }
        }

    }
}
