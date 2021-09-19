using System;
using HRM.Model.HR;
using HRM.Client.Helpers;
using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AntDesign;

namespace HRM.Client.Pages.Hr.Setting.Ethnicity
{
    partial class EthnicityForm : ComponentBase
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

        private Form<EthnicityModel> form;
        private EthnicityModel model = new EthnicityModel();

        private string pageTitle = "Thêm mới";
        private bool pageLoading = true;

        protected override async Task OnInitializedAsync()
        {
            DefineBreadcumb();
            if (Id.HasValue)
            {
                pageTitle = "Cập nhật";

                var result = await httpClientService.Get<EthnicityModel, HttpDataResponseWrapper<EthnicityModel>>($"hr/ethnicity/{Id.Value}");

                if (result != null)
                {
                    if (result.Succeeded == true)
                    {
                        model = result.Data;
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

        protected void BackToTheListClick()
        {
            navigationManager.NavigateTo("hr/setting/ethnicity");
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
                var response = await httpClientService.Put<EthnicityModel, HttpActionResponseWrapper>($"hr/ethnicity/{Id.Value}", model);
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
                var response = await httpClientService.Post<EthnicityModel, HttpActionResponseWrapper>("hr/ethnicity", model);
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
                Title = "Danh sách dân tộc",
                Href = "hr/setting/ethnicity",
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
