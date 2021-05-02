using System;
using System.Threading.Tasks;

namespace TehranStocks.ServicesInterfaces.Network
{
    public interface ITsetmcClient
    {
        Task<string> GetMarketWatchPlusAsync();
        Task<string> GetLoader111C1213Async();
        Task<string> GetLoader151311Async(string stockId);
        Task<string> GetExportTxtAsync(string stockId, DateTime from, DateTime to);
    }
}