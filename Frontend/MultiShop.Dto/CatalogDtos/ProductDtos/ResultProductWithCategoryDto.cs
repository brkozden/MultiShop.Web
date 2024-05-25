﻿using MultiShop.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.Dtos.CatalogDtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductDescription { get; set; }

        public ResultCategoryDto Category { get; set; }
    }
}
