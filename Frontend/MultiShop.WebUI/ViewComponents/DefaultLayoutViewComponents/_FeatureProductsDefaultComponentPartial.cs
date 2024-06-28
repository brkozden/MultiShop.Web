using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductService;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}
