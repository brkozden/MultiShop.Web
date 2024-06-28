using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderService;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
      private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}
