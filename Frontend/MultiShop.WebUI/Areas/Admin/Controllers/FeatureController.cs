using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureDefaultBreadcrumb();
            ViewBag.title4 = "Özellikler Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var values = await _featureService.GetAllFeaturesAsync();
            return View(values);
         
        }
        [Route("CreateFeature")]
        [HttpGet]
        public IActionResult CreateFeature()
        {
            FeatureDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Özellik Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateFeature")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
           
        }
        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureDefaultBreadcrumb();
            ViewBag.title4 = "Özellik Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _featureService.GetByIdFeatureAsync(id);
            return View(values);
    

        
        }
        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateFeatureDto updateFeatureDto)
        {

            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

         
        }
        public void FeatureDefaultBreadcrumb()
        {
            ViewBag.title1 = "Özellik İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Özellikler";
            ViewBag.Ikon1 = "fa fa-check-square-o";
        }
    }
}
