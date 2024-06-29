﻿using MultiShop.Dtos.CatalogDtos.ProductDetailDto;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);

        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetails/" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetails");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/GetProductDetailByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);
        }
    }
}
