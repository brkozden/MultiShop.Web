using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
     private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderDefaultBreadcrumb();
            ViewBag.title4 = "Öne Çıkanlar Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
           
        }
        [Route("CreateFeatureSlider")]
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Öne Çıkan Görseli Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateFeatureSlider")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

            


      
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
           
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderDefaultBreadcrumb();
            ViewBag.title4 = "Kategori Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
         
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {

            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

        }
        public void FeatureSliderDefaultBreadcrumb()
        {
            ViewBag.title1 = "Öne Çıkanlar İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Öne Çıkanlar";
            ViewBag.Ikon1 = "fa fa-diamond";
        }
    }
}
