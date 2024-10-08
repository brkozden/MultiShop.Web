﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductImageDto;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
      
        [Route("ProductImageDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ProductImageDefaultBreadcrumb();
            ViewBag.title4 = "Ürün Görseli Güncelleme";
            ViewBag.Ikon2 = "fa fa-pencil-square-o";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/ProductImages/ProductImagesByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }

            return View();
        }
        [Route("ProductImageDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7001/api/ProductImages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

            }

            return View();
        }
        public void ProductImageDefaultBreadcrumb()
        {
            ViewBag.title1 = "Ürün Görseli İşlemleri";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Ürünler";
            ViewBag.Ikon1 = "fa fa-picture-o";
        }
    }
}
