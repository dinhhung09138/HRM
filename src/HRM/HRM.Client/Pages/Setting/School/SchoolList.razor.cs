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

namespace HRM.Client.Pages.Setting.School
{
    partial class SchoolList : ComponentBase
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
        private List<SchoolGridModel> listData = new List<SchoolGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private SchoolGridParameterModel parameterModel = new SchoolGridParameterModel();

        private SchoolGridModel deletedItem = new SchoolGridModel();
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
            navigationManager.NavigateTo("setting/school/create");
        }

        protected void UpdateClick(SchoolGridModel item)
        {
            navigationManager.NavigateTo($"setting/school/update/{item.Id}");
        }

        protected void DeleteClick(SchoolGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<SchoolModel, HttpActionResponseWrapper>($"school/{deletedItem.Id}");
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
            var result = await httpClientService.Post<SchoolGridParameterModel, HttpDataResponseWrapper<Model.Grid<SchoolGridModel>>>("school/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<SchoolGridModel>();
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
                Title = "Danh sách trường đào tạo",
                IsActive = true,
            });
            StateHasChanged();
        }

    }
}
