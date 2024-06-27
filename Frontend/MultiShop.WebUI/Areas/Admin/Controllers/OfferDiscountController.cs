using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
     private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountDefaultBreadcrumb();
            ViewBag.title4 = "Günün İndirimleri Listesi";
            ViewBag.Ikon2 = "fa fa-list";
            var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);
           
        }
        [Route("CreateOfferDiscount")]
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountDefaultBreadcrumb();
            ViewBag.title4 = "Günlük İndirim Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
           
        }
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
           
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountDefaultBreadcrumb();
            ViewBag.title4 = "Günün İndirimini Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
           
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }
        public void OfferDiscountDefaultBreadcrumb()
        {
            ViewBag.title1 = "Günün İndirimleri İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Günün İndirimleri";
            ViewBag.Ikon1 = "fa fa-bullhorn";
        }
    }
}
