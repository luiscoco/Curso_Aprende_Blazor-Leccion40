using Microsoft.JSInterop;

namespace Leccion40.Components.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ShowAlert(this IJSRuntime jsRuntime, string message)
        { 
            await jsRuntime.InvokeVoidAsync("showAlert", message);
        }

        public static async Task<string> GetCurrentTime(this IJSRuntime jsRuntime)
        {
            string result = await jsRuntime.InvokeAsync<string>("getCurrentTime");
            return result;

        }
    }
}
