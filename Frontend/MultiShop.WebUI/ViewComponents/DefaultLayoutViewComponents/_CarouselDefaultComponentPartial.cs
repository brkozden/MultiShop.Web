using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
