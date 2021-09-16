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

namespace HRM.Client.Pages.Hr.Contacts.Customer
{
    partial class CustomerForm : ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IHttpClientService httpClientService { get; set; }

        [CascadingParameter(Name = "Bredcrumb")]
        public List<BreadcurmbModel> Breadcrumb { get; set; } = new List<BreadcurmbModel>();

        [Parameter]
        public long? Id { get; set; }

        private Form<CustomerModel> form;
        private CustomerModel model = new CustomerModel();

        private string pageTitle = "Thêm mới";
        private bool pageLoading = true;

        protected override async Task OnInitializedAsync()
        {
            DefineBreadcumb();

            if (Id.HasValue)
            {
                pageTitle = "Cập nhật";

                var result = await httpClientService.Get<CustomerModel, HttpDataResponseWrapper<CustomerModel>>($"hr/customer/{Id.Value}");

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
            }

            pageLoading = false;
            StateHasChanged();
        }

        protected void BackToTheListClick()
        {
            navigationManager.NavigateTo("hr/contacts/customer");
        }

        protected async Task OnFinish(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                return;
            }

            pageLoading = true;

            if (Id.HasValue)
            {
                var response = await httpClientService.Put<CustomerModel, HttpDataResponseWrapper<CustomerModel>> ($"hr/customer/{Id.Value}", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.UpdateSuccess();
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                }
                pageLoading = false;
            }
            else
            {
                var response = await httpClientService.Post<CustomerModel, HttpDataResponseWrapper<CustomerModel>>("hr/customer", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.CreateSuccess();
                    model = response.Data;
                    navigationManager.NavigateTo($"hr/contacts/customer/update/{model.Id}");
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                }
                pageLoading = false;
            }
            StateHasChanged();
        }

        protected string FormatMoney(decimal value)
        {
            return value.ToString("n0");
        }

        protected string ParseMoney(string value)
        {
            return Regex.Replace(value, @"\$\s?|(,*)", "");
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
                Title = "Danh sách khách hàng",
                Href = "hr/contacts/customer",
                IsActive = false,
            });

            if (Id.HasValue)
            {
                Breadcrumb.Add(new BreadcurmbModel()
                {
                    Title = "Cập nhật",
                    IsActive = true,
                });
            }
            else
            {
                Breadcrumb.Add(new BreadcurmbModel()
                {
                    Title = "Thêm mới",
                    IsActive = true,
                });
            }
            StateHasChanged();
        }

        protected void OnSubmitClick()
        {
            form.Submit();
        }

    }
}
