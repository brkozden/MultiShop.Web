using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        public   IActionResult Index(string id)
        {
            ViewBag.categoryId = id;
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
