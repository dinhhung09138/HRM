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

namespace HRM.Client.Pages.Hr.Setting.RelationshipType
{
    partial class RelationshipTypeForm : ComponentBase
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

        private Form<RelationshipTypeModel> form;
        private RelationshipTypeModel model = new RelationshipTypeModel();

        private string pageTitle = "Thêm mới";
        private bool pageLoading = true;

        protected override async Task OnInitializedAsync()
        {
            DefineBreadcumb();
            if (Id.HasValue)
            {
                pageTitle = "Cập nhật";

                var result = await httpClientService.Get<RelationshipTypeModel, HttpDataResponseWrapper<RelationshipTypeModel>>($"hr/relationship-type/{Id.Value}");

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
            navigationManager.NavigateTo("hr/setting/relationship-type");
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
                var response = await httpClientService.Put<RelationshipTypeModel, HttpActionResponseWrapper>($"hr/relationship-type/{Id.Value}", model);
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
                var response = await httpClientService.Post<RelationshipTypeModel, HttpActionResponseWrapper>("hr/relationship-type", model);
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
                Title = "Danh sách loại quan hệ gia đình",
                Href = "hr/setting/relationship-type",
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
