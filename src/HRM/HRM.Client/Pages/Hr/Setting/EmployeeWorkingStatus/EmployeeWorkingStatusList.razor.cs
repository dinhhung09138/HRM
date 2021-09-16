using System;
using System.Linq;
using HRM.Model.HR;
using HRM.Client.Models;
using HRM.Infrastructure;
using DotNetCore.Objects;
using HRM.Client.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using AntDesign;
using HRM.Client.Helpers;

namespace HRM.Client.Pages.Hr.Setting.EmployeeWorkingStatus
{
    partial class EmployeeWorkingStatusList : ComponentBase
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
        private List<EmployeeWorkingStatusGridModel> listData = new List<EmployeeWorkingStatusGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private EmployeeWorkingStatusGridParameterModel parameterModel = new EmployeeWorkingStatusGridParameterModel();

        private EmployeeWorkingStatusGridModel deletedItem = new EmployeeWorkingStatusGridModel();
        private bool isVisibleDeleteModel = false;

        protected async override Task OnInitializedAsync()
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
            navigationManager.NavigateTo("hr/setting/employee-working-status/create");
        }

        protected void UpdateClick(EmployeeWorkingStatusGridModel item)
        {
            navigationManager.NavigateTo($"hr/setting/employee-working-status/update/{item.Id}");
        }

        protected void DeleteClick(EmployeeWorkingStatusGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<EmployeeWorkingStatusModel, HttpActionResponseWrapper>($"hr/employee-working-status/{deletedItem.Id}");
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

            var result = await httpClientService.Post<EmployeeWorkingStatusGridParameterModel, HttpDataResponseWrapper<Model.Grid<EmployeeWorkingStatusGridModel>>>("hr/employee-working-status/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<EmployeeWorkingStatusGridModel>();
                totalItems = (int)result.Data.Count;
                tableLoading = false;
            }
            StateHasChanged();
        }

        private void DefineBreadcumb()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Quản lý nhân sự",
                Href = "hr",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Danh sách trạng thái nhân viên",
                IsActive = true,
            });
            StateHasChanged();
        }

    }
}
