using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TehranStocks.Domain.ServicesModels;

namespace TehranStocks.ServicesInterfaces.Network
{
    public interface ITsetmcService
    {
        Task<List<string>> GetStockIdListAsync();
        Task<List<string>> GetIndustryIdListAsync();
        Task<TsetmcTableau> GetStockDetails(string stockId);
        Task<string> GetStockPriceHistory(string stockId, DateTime from, DateTime to);
    }
}