using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferDefaultBreadcrumb();
            ViewBag.title4 = "Özel Teklifler Listesi";
            ViewBag.Ikon2 = "fa fa-list";
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);

        }
        [Route("CreateSpecialOffer")]
        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Özel Teklif Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateSpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

        }
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferDefaultBreadcrumb();
            ViewBag.title4 = "Özel Teklif Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);

        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        public void SpecialOfferDefaultBreadcrumb()
        {
            ViewBag.title1 = "Özel Teklif İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Özel Teklifler";
            ViewBag.Ikon1 = "fa fa-ticket";
        }
    }
}
