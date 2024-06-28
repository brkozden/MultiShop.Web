using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.BrandService;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendorDefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }
    }
}
