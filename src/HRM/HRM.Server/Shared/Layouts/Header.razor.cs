using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Server.Shared.Layouts
{
    public partial class Header
    {
        [Inject]
        public IJSRuntime js { get; set; }

        protected async Task ShowHideSidebar()
        {
            await js.InvokeVoidAsync("showHideMenu");
        }
    }
}
