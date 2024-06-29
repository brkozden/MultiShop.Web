using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductService;

namespace MultiShop.WebUI.ViewComponents.ProductsViewComponents
{
    public class _ProductListComponentPartial:ViewComponent
    {
      private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
           var values = await _productService.GetProductWithCategoryByCategoryIdAsync(id);
            return View(values);
        }
    }
}
