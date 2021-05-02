using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TehranStocks.ServicesInterfaces.Network;
using System.Collections.Generic;

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
        public async Task<ActionResult<List<string>>> Index()
        {
            return await _tsetmcService.GetStockIdList();
        }
    }
}