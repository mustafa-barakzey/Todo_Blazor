using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using Todo_Blazor;
using Todo_Blazor.Services.List;
using Todo_Blazor.Services.TaskList;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// inject services
builder.Services.AddScoped<ListService>();
builder.Services.AddScoped<TaskListService>();

builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5000/api/"),//builder.HostEnvironment.BaseAddress)
    };

    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzIiwidW5pcXVlX25hbWUiOiJicmsuRnJhbWV3b3JrLkJhc2UuVmFsdWVPYmplY3RzLkZpcnN0TmFtZSBicmsuRnJhbWV3b3JrLkJhc2UuVmFsdWVPYmplY3RzLkxhc3ROYW1lIiwibmJmIjoxNzA1MDE4MTk3LCJleHAiOjE3MDc2MTAxOTcsImlhdCI6MTcwNTAxODE5N30.xJ4EjXP1iHDJGa8wIL3Gan3P2TwttRMmQHQWpWsPVlU");

    return httpClient;
});

await builder.Build().RunAsync();
