using System.Collections.Generic;
using System.Threading.Tasks;

namespace TehranStocks.ServicesInterfaces.Network
{
    public interface ITsetmcService
    {
        Task<List<string>> GetStockIdList();
    }
}