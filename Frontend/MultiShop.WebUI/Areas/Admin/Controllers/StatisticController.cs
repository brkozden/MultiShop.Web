using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   

    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            StatisticDefaultBreadcrumb();

            long brandCount = await _catalogStatisticService.GetBrandCount();
            long categoryCount = await _catalogStatisticService.GetCategoryCount();
            long productCount = await _catalogStatisticService.GetProductCount();
            int userCount = await _userStatisticService.GetUserCount();
            int activeCommentCount = await _commentStatisticService.GetActiveCommentCount();
            int passiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();
            int totalCommentCount = await _commentStatisticService.GetTotalCommentCount();
            int discountCouponCount = await _discountStatisticService.GetDiscountCouponCount();
            int totalMessageCount = await _messageStatisticService.GetTotalMessageCount();

            // decimal productAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            string maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            string minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.brandCount = brandCount;
            ViewBag.categoryCount = categoryCount;
            ViewBag.productCount = productCount;
            ViewBag.maxPriceProductName = maxPriceProductName;
            ViewBag.minPriceProductName = minPriceProductName;
            ViewBag.userCount = userCount;
            ViewBag.activeCommentCount = activeCommentCount;
            ViewBag.passiveCommentCount = passiveCommentCount;
            ViewBag.totalCommentCount = totalCommentCount;
            ViewBag.discountCouponCount = discountCouponCount;
            ViewBag.totalMessageCount = totalMessageCount;

            //  ViewBag.productAvgPrice = productAvgPrice;

            return View();
        }
        public void StatisticDefaultBreadcrumb()
        {
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "İstatistikler";
            ViewBag.Ikon1 = "fa fa-bar-chart";
        }
    }
  
}
