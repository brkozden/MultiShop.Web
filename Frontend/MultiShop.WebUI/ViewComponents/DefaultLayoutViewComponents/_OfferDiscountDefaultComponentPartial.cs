using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountService;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _OfferDiscountDefaultComponentPartial:ViewComponent
    {
      private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);
        }
    }
}
