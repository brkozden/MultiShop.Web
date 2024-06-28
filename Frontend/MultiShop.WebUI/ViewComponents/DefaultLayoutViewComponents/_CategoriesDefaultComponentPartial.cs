using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryService;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _CategoriesDefaultComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
