using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductService;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code,int discountRate,decimal totalNewPriceWithDiscount,decimal discountAmount)
        {
            var values = await _basketService.GetBasket();
            ViewBag.Total = string.Format("{0:0,0}", values.TotalPrice).Replace(",", "."); 
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.Tax = string.Format("{0:0,0}", tax).Replace(",", ".");
            ViewBag.TotalPriceWithTax  = string.Format("{0:0,0}", totalPriceWithTax - ((totalPriceWithTax / 100 * discountRate))).Replace(",", ".");
            ViewBag.Code = code;
            ViewBag.DiscountRate = discountRate;
            ViewBag.TotalNewPriceWithDiscount ="-"+string.Format("{0:0,0}", totalNewPriceWithDiscount).Replace(",", ".") +"₺"; 
            ViewBag.DiscountAmount = string.Format("{0:0,0}", discountAmount).Replace(",", ".");
            if (discountAmount == 0 )
            {
                ViewBag.DiscountAmount = "Geçersiz İndirim Kodu";

            }

            return View();
        }
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                Price = values.ProductPrice,
                ProductName = values.ProductName,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl,
            };
            await _basketService.AddBasketItem(items);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
         
            await _basketService.RemoveBasketItem(id);

            return RedirectToAction("Index");
        }
    }
}
