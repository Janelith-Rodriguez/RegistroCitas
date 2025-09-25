using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegistroCitas.Client;
using RegistroCitas.Client.Autorizacion;
using RegistroCitas.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacion>();
await builder.Build().RunAsync();
