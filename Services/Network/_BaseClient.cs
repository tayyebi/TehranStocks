using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TehranStocks.ServicesInterfaces.Network;

namespace TehranStocks.Domain.RepositoriesInterfaces
{
    public class BaseClient
    {
        protected HttpClient _httpClient;
        public BaseClient (HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
    }
}