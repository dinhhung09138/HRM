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
using System.Linq;

namespace HRM.Client.Pages.Assets.Contract
{
    partial class ContractForm : ComponentBase
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

        private AssetContractModel model = new AssetContractModel();


        private string pageTitle = "Thêm mới";
        private bool pageLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadAssetTypeDropdown().ConfigureAwait(false);
            await LoadVendorDropdown().ConfigureAwait(false);

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Quản lý tài sản",
                Href = "asset",
                IsActive = false,
            });

            Breadcrumb.Add(new BreadcurmbModel()
            {
                Title = "Hợp đồng",
                Href = "asset/contract",
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

                var result = await httpClientService.Get<AssetContractModel, HttpDataResponseWrapper<AssetContractModel>>($"asset-contract/{Id.Value}");

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

        protected void BackToTheListClick()
        {
            navigationManager.NavigateTo("asset/contract");
        }

        protected void AddAssetItemClick()
        {
            if (model.Details == null)
            {
                model.Details = new List<AssetContractDetailModel>();
            }
            model.Details.Add(new AssetContractDetailModel());
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
                var response = await httpClientService.Put<AssetContractModel, HttpActionResponseWrapper>($"asset-contract/{Id.Value}", model);
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
                var response = await httpClientService.Post<AssetContractModel, HttpActionResponseWrapper>("asset-contract", model);
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

        protected string FormatMoney(float value)
        {
            return value.ToString("n0");
        }

        protected string ParseMoney(string value)
        {
            return Regex.Replace(value, @"\$\s?|(,*)", "");
        }

        protected void DetailValueChange(object value)
        {
            StateHasChanged();
        }

        protected void RemoveDetailItem(string rowId)
        {
            var item = model.Details.FirstOrDefault(m => m.RowId == rowId);
            if (item != null)
            {
                model.Details.Remove(item);
                StateHasChanged();
            }
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

    }
}
