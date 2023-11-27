using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;

namespace BlazorNet8;

public class ServerHostEnvironment(IWebHostEnvironment env, NavigationManager nav) : 
    IWebAssemblyHostEnvironment
{
    public string Environment => env.EnvironmentName;
    public string BaseAddress => nav.BaseUri;
}