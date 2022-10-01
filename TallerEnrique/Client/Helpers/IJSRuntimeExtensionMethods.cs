using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerEnrique.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string mensaje)
        {
            await js.InvokeVoidAsync("console.log", "prueba de console.log");
            return await js.InvokeAsync<bool>("confirm", mensaje);
        }

        //public  static void CargarCompra(this IJSRuntime js)
        //{
        //    js.InvokeVoidAsync("myfunction");
        //}
    }
}
