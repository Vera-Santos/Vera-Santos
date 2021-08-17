using BlazorDisplaySpinnerAutomatically;
using BlazorLets.Client.Shared.Services;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorLets.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBootstrapCss();

            builder.RootComponents.Add<App>("#app");

            // Acresccentado (Fonte de informação: https://bit.ly/37NfwZJ)
            builder.Services.AddHttpClient("BlazorLets.ServerAPI",
                client => client.BaseAddress = new Uri("https://localhost:5001/"));

            //Acrescentado (https://blazorstrap.io)
            builder.Services.AddBootstrapCss();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorLets.ServerAPI"));

            builder.Services.AddMudServices();

            builder.Services.AddApiAuthorization();

            // Acrescentado
            builder.Services.AddScoped<SpinnerService>();
            builder.Services.AddScoped<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
            builder.Services.AddScoped(s =>
            {
                var accessTokenHandler = s.GetRequiredService<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
                accessTokenHandler.InnerHandler = new HttpClientHandler();
                var uriHelper = s.GetRequiredService<NavigationManager>();
                return new HttpClient(accessTokenHandler)
                {
                    BaseAddress = new Uri(uriHelper.BaseUri)
                };
            });
            // Fim

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
