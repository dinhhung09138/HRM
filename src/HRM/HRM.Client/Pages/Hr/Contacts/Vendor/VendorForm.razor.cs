using System;
using HRM.Model;
using HRM.Model.HR;
using HRM.Client.Helpers;
using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HRM.Client.Pages.Hr.Contacts.Vendor
{
    partial class VendorForm : ComponentBase
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

        [Parameter]
        public long? Id { get; set; }

        private VendorModel model = new VendorModel();

        private string pageTitle = "Thêm mới";
        private bool pageLoading = true;

        protected override async Task OnInitializedAsync()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Quản lý nhân sự",
                Href = "hr/contacts",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Danh sách nhà cung cấp",
                Href = "hr/contacts/vendor",
                IsActive = false,
            });

            if (Id.HasValue)
            {
                pageTitle = "Cập nhật";

                Breadcrumb.Add(new BreadcurmbModel()
                {
                    Title = "Cập nhật",
                    IsActive = true,
                });
                StateHasChanged();

                var result = await httpClientService.Get<VendorModel, HttpDataResponseWrapper<VendorModel>>($"vendor/{Id.Value}");

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
            else
            {
                Breadcrumb.Add(new BreadcurmbModel()
                {
                    Title = "Thêm mới",
                    IsActive = true,
                });
                StateHasChanged();
            }

            pageLoading = false;
            StateHasChanged();
        }

        protected void BackToTheListClick()
        {
            navigationManager.NavigateTo("hr/contacts/vendor");
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
                var response = await httpClientService.Put<VendorModel, HttpActionResponseWrapper>($"vendor/{Id.Value}", model);
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
                var response = await httpClientService.Post<VendorModel, HttpActionResponseWrapper>("vendor", model);
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

    }
}
