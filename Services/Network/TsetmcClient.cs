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

        public async Task<string> GetMarketWatchPlusAsync()
        {
            var response = await _httpClient.GetAsync("/tsev2/data/MarketWatchPlus.aspx");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetLoader111C1213Async()
        {
            var response = await _httpClient.GetAsync("/Loader.aspx?ParTree=111C1213");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetLoader151311Async(string stockId)
        {
            var response = await _httpClient.GetAsync($"/Loader.aspx?ParTree=151311&i={stockId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetExportTxtAsync(string stockId, DateTime from, DateTime to)
        {
            string fromFormatted = from.ToString("yyyyMMdd");
            string toFormatted = to.ToString("yyyyMMdd");
            var response = await _httpClient.GetAsync($"http://www.tsetmc.com/tse/data/Export-txt.aspx?a=InsTrade&InsCode={stockId}&DateFrom={fromFormatted}&DateTo={toFormatted}&b=0");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}