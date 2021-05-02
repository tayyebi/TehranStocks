
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TehranStocks.ServicesInterfaces.Network;

namespace TehranStocks.Services.Network
{
    public class TsetmcService: ITsetmcService
    {
        private ITsetmcClient _tsetmcClient;
        public TsetmcService(ITsetmcClient tsetmcClient)
        {
            _tsetmcClient = tsetmcClient;
        }

        public async Task<List<string>> GetStockIdList()
        {
            var result = await _tsetmcClient.GetMessageAsync();
            var output = new List<string>();
            Regex rgx = new Regex("\\d{15,20}");
            foreach (Match match in rgx.Matches(result))
                output.Add(match.Value);
            return output;
        }

        
    }
}