using System;
using HRM.Model;
using HRM.Model.HR;
using HRM.Client.Helpers;
using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AntDesign;

namespace HRM.Client.Pages.Hr.Contacts.CustomerContact
{
    partial class CustomerContactForm : ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientService httpClientService { get; set; }

        [Parameter]
        public long? Id { get; set; }

        [Parameter]
        public EventCallback<bool> SubmitStatus { get; set; }

        private Form<CustomerContactModel> form;
        private CustomerContactModel model = new CustomerContactModel();

        private bool pageLoading = true;
        private bool ShowForm { get; set; } = false;

        protected void BackToTheListClick()
        {
            navigationManager.NavigateTo("hr/contacts/Customer");
        }

        protected async Task OnFinish(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                await SubmitStatus.InvokeAsync(false);
                return;
            }

            pageLoading = true;

            if (Id.HasValue)
            {
                var response = await httpClientService.Put<CustomerContactModel, HttpActionResponseWrapper>($"hr/customer-contact/{Id.Value}", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.UpdateSuccess();
                    pageLoading = false;
                    ShowForm = false;
                    await SubmitStatus.InvokeAsync(true);
                    form.Reset();
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                    await SubmitStatus.InvokeAsync(false);
                    pageLoading = false;
                }
            }
            else
            {
                var response = await httpClientService.Post<CustomerContactModel, HttpActionResponseWrapper>("hr/customer-contact", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.CreateSuccess();
                    pageLoading = false;
                    ShowForm = false;
                    await SubmitStatus.InvokeAsync(true);
                    form.Reset();
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                    await SubmitStatus.InvokeAsync(false);
                    pageLoading = false;
                }
            }
            StateHasChanged();
        }

        public void OnSubmitClick()
        {
            form.Submit();
        }

        public async Task OnShowForm(long? id, long customerId, bool showForm)
        {
            Id = id;
            pageLoading = false;
            model = new CustomerContactModel();
            model.CustomerId = customerId;
            ShowForm = showForm;
            if (id.HasValue)
            {
                await loadData(id.Value);
            }
            StateHasChanged();
        }

        private async Task loadData(long id)
        {
            pageLoading = true;
            var result = await httpClientService.Get<CustomerContactModel, HttpDataResponseWrapper<CustomerContactModel>>($"hr/customer-contact/{id}");

            if (result != null)
            {
                if (result.Succeeded == true)
                {
                    model = result.Data;
                }
                else
                {
                    await toastMessageHelper.Error(result.Message);
                }
            }

            pageLoading = false;
            StateHasChanged();
        }

    }
}
