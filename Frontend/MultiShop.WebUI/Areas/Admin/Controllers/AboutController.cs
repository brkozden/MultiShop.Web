using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]

    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            AboutDefaultBreadcrumb();
            ViewBag.title4 = "Hakkında Bilgisi Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var values = await _aboutService.GetAllAboutsAsync();
            return View(values);
        
        }
        [Route("CreateAbout")]
        [HttpGet]
        public IActionResult CreateAbout()
        {
            AboutDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Hakkında Bilgisi Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateAbout")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });

        }
        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
         
        }
        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            AboutDefaultBreadcrumb();
            ViewBag.title4 = "Hakkımda Bilgisi Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
          
        }
        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateAboutDto updateAboutDto)
        {

            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });

        }
        public void AboutDefaultBreadcrumb()
        {
            ViewBag.title1 = "Hakkında İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Hakkında";
            ViewBag.Ikon1 = "fa fa-info-circle";
        }
    }
}
