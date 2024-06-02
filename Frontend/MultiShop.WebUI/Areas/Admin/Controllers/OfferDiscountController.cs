using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountDefaultBreadcrumb();
            ViewBag.title4 = "Günün İndirimleri Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/OfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountDefaultBreadcrumb();
            ViewBag.title4 = "Günlük İndirim Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/OfferDiscounts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

            }


            return View();
        }
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7001/api/OfferDiscounts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountDefaultBreadcrumb();
            ViewBag.title4 = "Günün İndirimini Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/OfferDiscounts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
                return View(values);
            }

            return View();
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7001/api/OfferDiscounts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

            }

            return View();
        }
        public void OfferDiscountDefaultBreadcrumb()
        {
            ViewBag.title1 = "Günün İndirimleri İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Günün İndirimleri";
            ViewBag.Ikon1 = "fa fa-bullhorn";
        }
    }
}
