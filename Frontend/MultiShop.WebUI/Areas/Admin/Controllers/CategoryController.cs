using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {

            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryDefaultBreadcrumb();
            ViewBag.title4 = "Kategori Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
        [Route("CreateCategory")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            CategoryDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Kategori Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });


        }
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }
        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryDefaultBreadcrumb();
            ViewBag.title4 = "Kategori Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";

            var values = await _categoryService.GetByIdCategoryAsync(id);

            return View(values);

        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });


        }
        public void CategoryDefaultBreadcrumb()
        {
            ViewBag.title1 = "Kategori İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Kategoriler";
            ViewBag.Ikon1 = "fa fa-th";
        }
    }
}
