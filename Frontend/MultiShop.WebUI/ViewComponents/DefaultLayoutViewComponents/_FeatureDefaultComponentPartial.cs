using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
