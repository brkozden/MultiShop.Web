using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public   IActionResult Index(string id)
        {
            ViewBag.categoryId = id;
            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ViewBag.productId = id;
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto, string pid)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.CreatedDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7032/api/Comments" , content);
            if (responseMessage.IsSuccessStatusCode)
            {
               return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
