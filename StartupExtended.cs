using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TehranStocks.Database.Repositories;
using TehranStocks.Domain.RepositoriesInterfaces;
using TehranStocks.Services.Network;
using TehranStocks.ServicesInterfaces.Network;

namespace TehranStocks
{
    public static class StartupExtended
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITsetmcService, TsetmcService>();
        }

        public static void AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ITsetmcClient, TsetmcClient>("Tsetmc", c =>
            {
                c.AddClientDetails("Tsetmc", configuration);
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() {
                AutomaticDecompression = DecompressionMethods.GZip
                    | DecompressionMethods.Deflate
            });
        }
        private static void AddClientDetails(this HttpClient c, string networkDataProviderKey, IConfiguration configuration)
        {
            var networkDataProviderUrl = configuration.GetSection($"NetworkDataProviders:{networkDataProviderKey}:Url").Value;
            c.BaseAddress = new Uri(networkDataProviderUrl);
            var networkDataProviderHeaders = configuration.GetSection($"NetworkDataProviders:{networkDataProviderKey}:Headers").GetChildren();
            foreach (var networkDataProviderHeader in networkDataProviderHeaders)
                    c.DefaultRequestHeaders.Add(networkDataProviderHeader.Key, networkDataProviderHeader.Value);
        }
    }
}