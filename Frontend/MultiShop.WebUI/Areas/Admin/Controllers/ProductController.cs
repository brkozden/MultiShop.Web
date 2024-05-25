using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
     
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Ürün Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Ürün Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId,
                                                   }).ToList();
            ViewBag.Categories = categoryValues;

            return View();
        }
        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }


            return View();
        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7001/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Ürün Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var categoryClient = _httpClientFactory.CreateClient();
            var responseMessageCategory = await categoryClient.GetAsync("https://localhost:7001/api/Categories");
            var categoryJsonData = await responseMessageCategory.Content.ReadAsStringAsync();
            var categoryValue = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);

            List<SelectListItem> categoryValues = (from x in categoryValue
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId,
                                                   }).ToList();
            ViewBag.Categories = categoryValues;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }

            

            return View();
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7001/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }

            return View();
        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Ürün Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public void ProductDefaultBreadcrumb()
        {
            ViewBag.title1 = "Ürün İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Ürünler";
            ViewBag.Ikon1 = "fa fa-cubes";
        }
    }
}
