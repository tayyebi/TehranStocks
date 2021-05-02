using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TehranStocks.ServicesInterfaces.Network;

namespace TehranStocks.Domain.RepositoriesInterfaces
{
    public class TsetmcClient : BaseClient, ITsetmcClient
    {

        public TsetmcClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<string> GetMessageAsync()
        {
            var response = await _httpClient.GetAsync("/tsev2/data/MarketWatchPlus.aspx");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}