using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Services.OfferDiscountService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _OfferDiscountService;

        public OfferDiscountsController(IOfferDiscountService OfferDiscountService)
        {
            _OfferDiscountService = OfferDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _OfferDiscountService.GetAllOfferDiscountsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountByIdList(string id)
        {
            var values = await _OfferDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Yeni Özellik Eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _OfferDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("Özellik Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Özellik Güncellendi.");
        }
    }
}
