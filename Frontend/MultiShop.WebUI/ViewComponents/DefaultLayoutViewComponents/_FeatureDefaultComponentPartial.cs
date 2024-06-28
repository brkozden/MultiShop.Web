﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureService;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {
      private readonly IFeatureService _featureService;

        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeaturesAsync();
            return View(values);
            
        }
    }
}
