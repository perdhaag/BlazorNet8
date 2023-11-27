using BlazorNet8.Core.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<ITodoService, TodoService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["Api:BaseUrl"]!);
});
await builder.Build().RunAsync();
