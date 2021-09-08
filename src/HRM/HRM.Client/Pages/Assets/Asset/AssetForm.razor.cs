using System;
using HRM.Model;
using HRM.Model.Assets;
using HRM.Client.Helpers;
using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Constant.Enums;
using HRM.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AntDesign;


namespace HRM.Client.Pages.Assets.Asset
{
    partial class AssetForm : ComponentBase
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

        private List<BaseSelectboxModel> vendorList = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> assetTypeList = new List<BaseSelectboxModel>();
        private List<BaseSelectboxModel> assetStatusList = new List<BaseSelectboxModel>();

        private Form<AssetModel> form;
        private AssetModel model = new AssetModel();

        private string pageTitle = "Thêm mới";
        private bool pageLoading = true;

        protected override async Task OnInitializedAsync()
        {
            DefineBreadcumb();
            await LoadAssetTypeDropdown().ConfigureAwait(false);
            await LoadVendorDropdown().ConfigureAwait(false);
            LoadAssetStatusDropdown();

            if (Id.HasValue)
            {
                pageTitle = "Cập nhật";

                var result = await httpClientService.Get<AssetModel, HttpDataResponseWrapper<AssetModel>>($"asset/{Id.Value}");

                if (result != null)
                {
                    if (result.Succeeded == true)
                    {
                        model = result.Data;
                        model.AssetTypeIdValue = model.AssetTypeId.ToString();
                        model.VendorIdValue = model.VendorId.ToString();
                        model.AssetStatusValue = model.AssetStatus.ToString();
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
            navigationManager.NavigateTo("asset/list");
        }

        protected async Task OnFinish(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                return;
            }

            pageLoading = true;

            if (!string.IsNullOrEmpty(model.AssetTypeIdValue))
            {
                model.AssetTypeId = long.Parse(model.AssetTypeIdValue);
            }

            if (!string.IsNullOrEmpty(model.VendorIdValue))
            {
                model.VendorId = long.Parse(model.VendorIdValue);
            }

            if (!string.IsNullOrEmpty(model.AssetStatusValue))
            {
                model.AssetStatus = (AssetStatus)Enum.Parse(typeof(AssetStatus), model.AssetStatusValue);
            }

            if (Id.HasValue)
            {
                var response = await httpClientService.Put<AssetModel, HttpActionResponseWrapper>($"asset/{Id.Value}", model);
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
                var response = await httpClientService.Post<AssetModel, HttpActionResponseWrapper>("asset", model);
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

        protected string FormatMoney(decimal value)
        {
            return value.ToString("n0");
        }

        protected string ParseMoney(string value)
        {
            return Regex.Replace(value, @"\$\s?|(,*)", "");
        }

        private async Task LoadAssetTypeDropdown()
        {
            assetTypeList = await selectboxDataHelper.GetAssetType();
            StateHasChanged();
        }

        private async Task LoadVendorDropdown()
        {
            vendorList = await selectboxDataHelper.GetVendor();
            StateHasChanged();
        }

        private void LoadAssetStatusDropdown()
        {
            assetStatusList = selectboxDataHelper.GetAssetStatus();
            StateHasChanged();
        }

        private void DefineBreadcumb()
        {
            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Quản lý tài sản",
                Href = "asset",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Danh sách tài sản",
                Href = "asset/list",
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
