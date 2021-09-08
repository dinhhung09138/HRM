using System;
using System.Linq;
using HRM.Model.Common;
using HRM.Client.Models;
using HRM.Infrastructure;
using DotNetCore.Objects;
using HRM.Client.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using AntDesign;
using HRM.Client.Helpers;

namespace HRM.Client.Pages.Setting.MaritalStatus
{
    partial class MaritalStatusList : ComponentBase
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
        private List<MaritalStatusGridModel> listData = new List<MaritalStatusGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private MaritalStatusGridParameterModel parameterModel = new MaritalStatusGridParameterModel();

        private MaritalStatusGridModel deletedItem = new MaritalStatusGridModel();
        private bool isVisibleDeleteModel = false;

        protected override async Task OnInitializedAsync()
        {
            DefineBreadcumb();
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
            navigationManager.NavigateTo("setting/marital-status/create");
        }

        protected void UpdateClick(MaritalStatusGridModel item)
        {
            navigationManager.NavigateTo($"setting/marital-status/update/{item.Id}");
        }

        protected void DeleteClick(MaritalStatusGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<MaritalStatusModel, HttpActionResponseWrapper>($"marital-status/{deletedItem.Id}");
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
            var result = await httpClientService.Post<MaritalStatusGridParameterModel, HttpDataResponseWrapper<Model.Grid<MaritalStatusGridModel>>>("marital-status/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<MaritalStatusGridModel>();
                totalItems = (int)result.Data.Count;
                tableLoading = false;
            }
            StateHasChanged();
        }

        private void DefineBreadcumb()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Thiết lập",
                Href = "setting",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Danh sách tình trạng hôn nhân",
                IsActive = true,
            });
            StateHasChanged();
        }

    }
}
