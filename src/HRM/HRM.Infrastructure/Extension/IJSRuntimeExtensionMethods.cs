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
        /// <summary>
        /// Initize all selectboxs.
        /// Please add class select-single or select-multiple into the select element
        /// </summary>
        /// <param name="js"></param>
        /// <param name="id">control id</param>
        /// <param name="isMultiple">Multiple selection true/false</param>
        /// <param name="dotNetObjectReference">DotNet Object References</param>
        /// <param name="selectedFuncCallback">The function after select2 change</param>
        /// <returns></returns>
        public static async ValueTask InitialSelectBox<T>(this IJSRuntime js, string id, bool isMultiple, DotNetObjectReference<T> dotNetObjectReference, string selectedFuncCallback) where T : class
        {
            await js.InvokeVoidAsync("initialSelectBox", id, isMultiple, dotNetObjectReference, selectedFuncCallback);
        }

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
