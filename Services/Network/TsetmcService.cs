
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TehranStocks.Domain.ServicesModels;
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

        public async Task<List<string>> GetStockIdListAsync()
        {
            var result = await _tsetmcClient.GetMarketWatchPlusAsync();
            var output = new List<string>();
            Regex rgx = new Regex("\\d{15,20}");
            foreach (Match match in rgx.Matches(result))
                output.Add(match.Value);
            return output;
        }

        public async Task<List<string>> GetIndustryIdListAsync()
        {
            var result = await _tsetmcClient.GetLoader111C1213Async();
            var output = new List<string>();
            Regex rgx = new Regex("\\d{2,3}");
            foreach (Match match in rgx.Matches(result))
                output.Add(match.Value);
            return output;
        }


        private string TryFetch(string text, string pattern)
        {
            var regex = new Regex(pattern);
            var match = regex.Matches(text);
            if (match.Count > 0)
                return match[0].Groups[1].Captures[0].Value;
            else return string.Empty;
        }

        public async Task<TsetmcTableau> GetStockDetails(string stockId)
        {
            var result = await _tsetmcClient.GetLoader151311Async(stockId);
            
            // TODO: Rename fields to human-readable variable names
            var name = TryFetch(result, "LVal18AFC='([\\D]*)',");
            var instrumentId = TryFetch(result, "InstrumentID='([\\w\\d]*)|$',");
            var inscode = TryFetch(result, "InsCode='(\\d*)',");
            var baseVol = TryFetch(result, "BaseVol=([\\.\\d]*),");
            var groupName = TryFetch(result, "LSecVal='([\\D]*)',");
            var groupCode = TryFetch(result, "CSecVal='([\\w\\d]*)|$',");
            var title = TryFetch(result, "Title='([\\D]*)',");
            var shareCount = TryFetch(result, "ZTitad=([\\.\\d]*),");
            var estimatedEps = TryFetch(result, "EstimatedEPS='([\\.\\d]*)',");
            var sectorPe = TryFetch(result, "SectorPE='([\\.\\d]*)',");

            var output = new TsetmcTableau {
                Name = name,
                InstrumentId = instrumentId,
            };

            return output;
        }

        public async Task<string> GetStockPriceHistory(string stockId, DateTime from, DateTime to)
        {
            var result = await _tsetmcClient.GetExportTxtAsync(stockId, from, to);
            return result;
        }
    }
}