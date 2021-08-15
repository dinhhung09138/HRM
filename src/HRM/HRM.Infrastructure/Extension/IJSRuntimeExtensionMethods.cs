using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace HRM.Infrastructure.Extension
{
    public static class IJSRuntimeExtensionMethods
    {

        public static ValueTask<T> SetInLocalStorage<T>(this IJSRuntime js, string key, T content)
            => js.InvokeAsync<T>("localStorage.setItem", key, content);

        public static ValueTask<T> GetFromLocalStorage<T>(this IJSRuntime js, string key)
           => js.InvokeAsync<T>("localStorage.getItem", key);

        public static ValueTask<T> RemoveItem<T>(this IJSRuntime js, string key)
            => js.InvokeAsync<T>("localStorage.removeItem", key);
    }
}
