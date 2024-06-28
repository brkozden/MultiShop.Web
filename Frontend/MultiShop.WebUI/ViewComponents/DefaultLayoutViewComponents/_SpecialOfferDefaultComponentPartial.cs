using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _SpecialOfferDefaultComponentPartial:ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
