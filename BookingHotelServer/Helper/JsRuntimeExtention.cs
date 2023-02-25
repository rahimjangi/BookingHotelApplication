using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace BookingHotelServer.Helper
{
    public static class JsRuntimeExtention
    {
        public static async void SwAlert(this IJSRuntime jSRuntime,string messageType,string message)
        {
            await jSRuntime.InvokeVoidAsync("SwAlert", messageType,message);
        }
    }
}
