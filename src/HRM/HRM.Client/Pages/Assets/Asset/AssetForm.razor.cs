using HRM.Client.Helpers;
using HRM.Client.Models;
using HRM.Client.Services;
using HRM.Constant.Enums;
using HRM.Infrastructure;
using HRM.Infrastructure.Extension;
using HRM.Model;
using HRM.Model.Assets;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRM.Client.Pages.Assets.Asset
{
    partial class AssetForm : ComponentBase
    {
        [Inject]
        public ToastMessageHelper toastMessageHelper { get; set; }

        [Inject]
        public IJSRuntime js { get; set; }

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

        private AssetModel model = new AssetModel();

        private string pageTitle = "Thêm mới";

        private bool pageLoading = true;

        public AssetForm()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadAssetTypeDropdown().ConfigureAwait(false);
            await LoadVendorDropdown().ConfigureAwait(false);
            LoadAssetStatusDropdown();

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
                pageTitle = "Cập nhật";

                Breadcrumb.Add(new BreadcurmbModel()
                {
                    Title = "Cập nhật",
                    IsActive = true,
                });

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
                    BackToTheList();
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
                    BackToTheList();
                }
                else
                {
                    await toastMessageHelper.Error(response.Message);
                    pageLoading = false;
                }
            }
            StateHasChanged();
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

        private string FormatMoney(decimal value)
        {
            return value.ToString("n0");
        }

        private string ParseMoney(string value)
        {
            return Regex.Replace(value, @"\$\s?|(,*)", "");
        }
    }
}
