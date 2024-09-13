# CURSO: APRENDE BLAZOR

# LECCIÓN 40: Extensiones de JSRuntime

En esta lección vamos a definir una clase que extiende al interface IJSRuntime en Blazor, permitiendo un interacción más fácil con las funciones de JavaScript desde los componentes de Blazor. 

Esta nueva clase encapsula las funciones de JavaScript en métodos de C# reutilizables.

1. Abrir la aplicación con Visual Studio 2022 o VSCode

2. Creamos un archivo de JavaScript example.js dentro de la carpeta wwwroot/js donde definimos las funciones de JavaScript que vamos a invocar en nuestra aplicación de Blazor

```javascript
   window.showAlert = (message) => {
    alert(message);
}

window.getCurrentTime = () => {
    return new Date().toLocaleTimeString();
}

3. Creamos un nuevo componente NuevoComponente.razor desde donde vamos a invocar a las funciones de JavaScript definidas en el archivo example.js

```razor
@page "/jsinterop"
@using Leccion40.Components.Helper
@inject IJSRuntime JSRuntime

<h3>JS Runtime Interop Example</h3>

<button @onclick="ShowAlert">Show Alert</button>
<button @onclick="GetCurrentTime">Get Current Time</button>

<p>@currentTime</p>

@code {
    private string? currentTime;

    private async Task ShowAlert()
    {
        // Call the 'showAlert' JavaScript function
        await JSRuntime.InvokeVoidAsync("showAlert", "Hello from Blazor!");
        //await JSRuntime.ShowAlert("Hello from Blazor!");
    }

    private async Task GetCurrentTime()
    {
        // Call the 'getCurrentTime' JavaScript function and get its result
        currentTime = await JSRuntime.InvokeAsync<string>("getCurrentTime");
        //currentTime = await JSRuntime.GetCurrentTime();
    }
}
```

4. Creamos las extensiones de JSRuntime en el archivo Components/Helper/IJSRuntimeExtensions.cs

```csharp
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
```

5. Ejecutamos la aplicación y vemos el resultado

