using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dtos.CatalogDtos.ProductDetailDto;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryService;
using MultiShop.WebUI.Services.CatalogServices.ProductService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IProductService productService, ICategoryService categoryService, IHttpClientFactory httpClientFactory)
        {
            _productService = productService;
            _categoryService = categoryService;
            _httpClientFactory = httpClientFactory;
        }

       

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Ürün Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var values = await _productService.GetAllProductsAsync();
            return View(values);

        }
        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Ürün Ekle";
            ViewBag.Ikon2 = "fa fa-plus-square";


            var values = await _categoryService.GetAllCategoriesAsync();

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
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto, CreateProductDetailDto createProductDetailDto, ResultProductDto resultProductDto)
        {


            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductDefaultBreadcrumb();
            ViewBag.title4 = "Ürün Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var values = await _categoryService.GetAllCategoriesAsync();

            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId,
                                                   }).ToList();
            ViewBag.Categories = categoryValues;

          var productValues = await _productService.GetByIdProductAsync(id);
                return View(productValues);
            



            return View();
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });


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
