﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
