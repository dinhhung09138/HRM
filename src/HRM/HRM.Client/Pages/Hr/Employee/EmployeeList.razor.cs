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

namespace HRM.Client.Pages.Hr.Employee
{
    partial class EmployeeList : ComponentBase
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
        private List<EmployeeGridModel> listData = new List<EmployeeGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private EmployeeGridParameterModel parameterModel = new EmployeeGridParameterModel();

        private EmployeeGridModel deletedItem = new EmployeeGridModel();
        private bool isVisibleDeleteModel = false;

        protected async override Task OnInitializedAsync()
        {
            DefineBreadcumb();
            tableLoading = false;
            listData.Add(new EmployeeGridModel()
            {
                Code = "NV0001",
                Name = "Trần Đình Hưng",
                Position = "IT department",
                Email = "email@gmail.com",
                Phone = "0987.4875.566"
            });
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
            navigationManager.NavigateTo("hr/employee/create");
        }

        protected void UpdateClick(EmployeeGridModel item)
        {
            navigationManager.NavigateTo($"hr/employee/update/{item.Id}");
        }

        protected void DeleteClick(EmployeeGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<EmployeeGridModel, HttpActionResponseWrapper>($"hr/employee/{deletedItem.Id}");
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

            var result = await httpClientService.Post<EmployeeGridParameterModel, HttpDataResponseWrapper<Model.Grid<EmployeeGridModel>>>("hr/employee/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<EmployeeGridModel>();
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
                Href = "hr/contacts",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Danh sách nhân viên",
                IsActive = true,
            });
            StateHasChanged();
        }

    }
}
