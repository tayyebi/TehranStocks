using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TehranStocks.ServicesInterfaces.Network;
using System.Collections.Generic;
using TehranStocks.Domain.ServicesModels;
using System;

namespace TehranStocks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TsetmcController : ControllerBase
    {
        private ITsetmcService _tsetmcService;
        public TsetmcController(ITsetmcService tsetmcService)
        {
            _tsetmcService = tsetmcService;
        }

        [HttpGet("GetStockIdList")]
        public async Task<ActionResult<List<string>>> GetStockIdList()
        {
            return await _tsetmcService.GetStockIdListAsync();
        }
        
        [HttpGet("GetIndustryIdList")]
        public async Task<ActionResult<List<string>>> GetIndustryIdList()
        {
            return await _tsetmcService.GetIndustryIdListAsync();
        }
        
        [HttpGet("GetStockDetails/{stockId}")]
        public async Task<ActionResult<TsetmcTableau>> GetStockDetails(string stockId = "65883838195688438")
        {
            return await _tsetmcService.GetStockDetails(stockId);
        }

        [HttpGet("GetStockPriceHistory/{stockId}")]
        public async Task<ActionResult<string>> GetStockPriceHistory(string stockId, DateTime from, DateTime to)
        {
            return await _tsetmcService.GetStockPriceHistory(stockId, from, to);
        }
    }
}