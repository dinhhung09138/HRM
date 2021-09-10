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

namespace HRM.Client.Pages.Hr.Contacts.CustomerContact
{
    partial class CustomerContactList : ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientService httpClientService { get; set; }

        [Parameter]
        public long CustomerId { get; set; }

        private bool tableLoading = true;
        private List<CustomerContactGridModel> listData = new List<CustomerContactGridModel>();
        private int totalItems = 0;
        Func<PaginationTotalContext, string> showTotal = ctr => $"Tổng: {ctr.Total} dòng";

        private CustomerContactGridParameterModel parameterModel = new CustomerContactGridParameterModel();

        private CustomerContactGridModel deletedItem = new CustomerContactGridModel();
        private bool isVisibleDeleteModel = false;

        CustomerContactForm editForm;

        private bool showEditForm = false;

        public CustomerContactList()
        {
            parameterModel.CustomerId = CustomerId;
        }

        protected async override Task OnInitializedAsync()
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
            showEditForm = true;
            editForm.OnShowForm(null, CustomerId, true);
        }

        protected void OnSubmitClick()
        {
            editForm.OnSubmitClick();
        }

        protected void UpdateClick(CustomerContactGridModel item)
        {
            showEditForm = true;
            editForm.OnShowForm(item.Id, CustomerId, true);
        }

        protected void OnCancelClick()
        {
            editForm.OnShowForm(null, CustomerId, false);
            showEditForm = false;
        }

        protected async Task OnFormResonseStatus(bool status)
        {
            if (status == true)
            {
                showEditForm = false;
                await LoadGridData();
                StateHasChanged();
            }
        }

        protected void DeleteClick(CustomerContactGridModel item)
        {
            deletedItem = item;
            isVisibleDeleteModel = true;
        }

        protected async Task AgreeDeleteClick()
        {
            var result = await httpClientService.Delete<CustomerContactModel, HttpActionResponseWrapper>($"customer-contact/{deletedItem.Id}");
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
            parameterModel.CustomerId = CustomerId;
            tableLoading = true;

            var result = await httpClientService.Post<CustomerContactGridParameterModel, HttpDataResponseWrapper<Model.Grid<CustomerContactGridModel>>>("customer-contact/grid", parameterModel);
            if (result != null)
            {
                listData = result.Data.List?.ToList() ?? new List<CustomerContactGridModel>();
                totalItems = (int)result.Data.Count;
                tableLoading = false;
            }
            StateHasChanged();
        }

    }
}
