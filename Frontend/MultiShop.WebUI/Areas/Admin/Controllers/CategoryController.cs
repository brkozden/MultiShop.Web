using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryDefaultBreadcrumb();
            ViewBag.title4 = "Kategori Listesi";
            ViewBag.Ikon2 = "fa fa-list";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateCategory")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            CategoryDefaultBreadcrumb();
            ViewBag.title4 = "Yeni Kategori Ekleme";
            ViewBag.Ikon2 = "fa fa-plus-square";
            return View();
        }
        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });

            }


            return View();
        }
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7001/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryDefaultBreadcrumb();
            ViewBag.title4 = "Kategori Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
           
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync("https://localhost:7001/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });

            }

            return View();
        }
        public void CategoryDefaultBreadcrumb()
        {
            ViewBag.title1 = "Kategori İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Kategoriler";
            ViewBag.Ikon1 = "fa fa-th";
        }
    }
}
