using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Service.Interfaces;
using Service.Services;
using Service.Models;
using Web.Services;
using Microsoft.JSInterop;
using CurrieTechnologies.Razor.SweetAlert2;
using Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Servicios genéricos
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
// Registro explícito de modelos usados
builder.Services.AddScoped<IGenericService<Cliente>, GenericService<Cliente>>();
builder.Services.AddScoped<IGenericService<Localidad>, GenericService<Localidad>>();
builder.Services.AddScoped<IGenericService<Producto>, GenericService<Producto>>();
builder.Services.AddScoped<IGenericService<Categoria>, GenericService<Categoria>>();
builder.Services.AddScoped<IGenericService<Marca>, GenericService<Marca>>();
builder.Services.AddScoped<IGenericService<Proveedor>, GenericService<Proveedor>>();

builder.Services.AddScoped<FirebaseAuthService>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
