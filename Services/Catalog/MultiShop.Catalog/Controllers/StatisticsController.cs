using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount() 
        {
            return Ok(_statisticService.GetBrandCount());
         }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_statisticService.GetCategoryCount());
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_statisticService.GetProductCount());
        }
        [HttpGet("GetProductAvgPrice")]
        public IActionResult GetProductAvgPrice()
        {
            return Ok(_statisticService.GetProductAvgPrice());
        }
        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            return Ok(await _statisticService.GetMaxPriceProductName());
        }
        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            return Ok(await _statisticService.GetMinPriceProductName());
        }
    }
}
