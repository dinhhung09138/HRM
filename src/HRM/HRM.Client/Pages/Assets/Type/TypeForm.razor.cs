﻿using System;
using HRM.Model.Assets;
using HRM.Client.Models;
using HRM.Infrastructure;
using HRM.Client.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HRM.Client.Pages.Assets.Type
{
    partial class TypeForm : ComponentBase
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

        private AssetTypeModel model = new AssetTypeModel();

        private string pageTitle = "Thêm mới";

        private bool pageLoading = true;

        public TypeForm()
        {

        }

        protected override async Task OnInitializedAsync()
        {

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Quản lý tài sản",
                Href = "asset",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Loại tài sản",
                Href = "asset/type",
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

                var result = await httpClientService.Get<AssetTypeModel, HttpDataResponseWrapper<AssetTypeModel>>($"asset-type/{Id.Value}");

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
            }

            pageLoading = false;
            StateHasChanged();
        }

        protected void BackToTheList()
        {
            navigationManager.NavigateTo("asset/type");
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
                var response = await httpClientService.Put<AssetTypeModel, HttpActionResponseWrapper>($"asset-type/{Id.Value}", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.UpdateSuccess();
                    BackToTheList();
                }
                else
                {
                    await toastMessageHelper.UpdateError();
                    pageLoading = false;
                }
            }
            else
            {
                var response = await httpClientService.Post<AssetTypeModel, HttpActionResponseWrapper>("asset-type", model);
                if (response.Succeeded)
                {
                    await toastMessageHelper.CreateSuccess();
                    BackToTheList();
                }
                else
                {
                    await toastMessageHelper.CreateError();
                    pageLoading = false;
                }
            }
            StateHasChanged();
        }

    }
}