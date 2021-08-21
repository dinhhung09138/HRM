using HRM.Client.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Client.Shared.Layouts
{
    public partial class Header
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider authenticationStateProvide { get; set; }

        [Inject]
        public IJSRuntime js { get; set; }

        protected async Task ShowHideSidebar()
        {
            await js.InvokeVoidAsync("showHideMenu");
        }

        protected async Task LogoutClick()
        {
            await ((HrmAuthenticationStateProvider)authenticationStateProvide).DoLogout();
            navigationManager.NavigateTo("/login");
        }
    }
}
