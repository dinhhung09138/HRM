using System;
using HRM.Model;
using HRM.Model.HR;
using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AntDesign;
using HRM.Client.Helpers;

namespace HRM.Client.Pages.Hr.Employee.Components
{
    partial class Official : ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientService httpClientService { get; set; }

        [Inject]
        public SelectboxDataHelper selectboxDataHelper { get; set; }

        [Parameter]
        public long? EmployeeId { get; set; }

        private Form<EmployeeModel> form;
        private EmployeeModel model = new EmployeeModel();
        private EmployeeModel originalModel = new EmployeeModel();

        private bool pageLoading = true;
        private bool editForm = false;

        private List<BaseSelectboxModel> listBranch = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> listDepartment = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> listPosition = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> listJobPosition = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> listManager = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> listEmployeeWorkingStatus = new List<BaseSelectboxModel>();

        protected override async Task OnInitializedAsync()
        {
            await GetListBranch();
            await GetListDepartment();
            await GetListPosition();
            await GetListJobPosition();
            await GetListManager();
            await GetListEmployeeWorkingStatus();

            if (EmployeeId.HasValue)
            {
                var result = await httpClientService.Get<EmployeeModel, HttpDataResponseWrapper<EmployeeModel>>($"hr/employee/{EmployeeId.Value}");

                if (result != null)
                {
                    if (result.Succeeded == true)
                    {
                        model = result.Data;
                        originalModel = result.Data;
                        StateHasChanged();
                    }
                    else
                    {
                        await toastMessageHelper.Error(result.Message);
                    }
                }
            }
            
            pageLoading = false;
            StateHasChanged();
        }

        private async Task GetListEmployeeWorkingStatus()
        {
            var listEmployeeWorkingStatus = await selectboxDataHelper.GetEmployeeWorkingStatus();
        }

        protected void BackToTheListClick()
        {
            navigationManager.NavigateTo("hr/employees");
        }

        protected async Task OnFinish(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                return;
            }

            pageLoading = true;

            if (EmployeeId.HasValue)
            {
                var response = await httpClientService.Put<EmployeeModel, HttpDataResponseWrapper<EmployeeModel>>($"hr/employee/{EmployeeId.Value}", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.UpdateSuccess();
                    BackToTheListClick();
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                    pageLoading = false;
                }
            }
            else
            {
                var response = await httpClientService.Post<EmployeeModel, HttpDataResponseWrapper<EmployeeModel>>("hr/employee", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.CreateSuccess();
                    BackToTheListClick();
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                    pageLoading = false;
                }
            }
            StateHasChanged();
        }

        protected void OnShowFormClick()
        {
            editForm = true;
            StateHasChanged();
        }

        protected void OnCancelClick()
        {
            editForm = false;
            model = originalModel.Clone();
            StateHasChanged();
        }

        protected void OnSubmitClick()
        {
            form.Submit();
        }

        private async Task GetListBranch()
        {
            var listBranch = await selectboxDataHelper.GetBranch();
            StateHasChanged();
        }

        private async Task GetListDepartment()
        {
            var listDepartment = await selectboxDataHelper.GetDepartment();
            StateHasChanged();
        }

        private async Task GetListPosition()
        {
            var listPosition = await selectboxDataHelper.GetPosition();
            StateHasChanged();
        }

        private async Task GetListJobPosition()
        {
            var listJobPosition = await selectboxDataHelper.GetJobPosition();
            StateHasChanged();
        }

        private async Task GetListManager()
        {
            var listManager = await selectboxDataHelper.GetManager();
            StateHasChanged();
        }

    }
}
