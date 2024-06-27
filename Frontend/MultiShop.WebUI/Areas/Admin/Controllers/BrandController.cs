using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            BrandDefaultBreadcrumb();
            ViewBag.title4 = "Marka Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
          
        }
        [Route("CreateBrand")]
        [HttpGet]
        public IActionResult CreateBrand()
        {
            BrandDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Marka Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateBrand")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }
        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
           
        }
        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandDefaultBreadcrumb();
            ViewBag.title4 = "Marka Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        
        }
        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateBrandDto updateBrandDto)
        {

            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }
        public void BrandDefaultBreadcrumb()
        {
            ViewBag.title1 = "Marka İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Markalar";
            ViewBag.Ikon1 = "fa fa-link";
        }
    }
}
