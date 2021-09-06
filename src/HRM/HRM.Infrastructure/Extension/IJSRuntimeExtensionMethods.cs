using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HRM.Infrastructure.Extension
{
    public static class IJSRuntimeExtensionMethods
    {
        public static void Log(this IJSRuntime js, string message)
        {
            js.InvokeVoidAsync("console.log", message);
        }

        public static async ValueTask LogAsync(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("console.log", message);
        }

        public static async ValueTask ExpandSidebar(this IJSRuntime js, string id)
        {
            await js.InvokeVoidAsync("expandSidebar", id);
        }

        public static async ValueTask InitializeInactiveTimer<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initilizeInactivityTimer", dotNetObjectReference);
        }
    }
}
