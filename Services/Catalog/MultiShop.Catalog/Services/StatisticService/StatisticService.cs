﻿using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticService
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);

        }

        public long GetBrandCount()
        {
            return _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
        }

        public long GetCategoryCount()
        {
            return _categoryCollection.CountDocuments(FilterDefinition<Category>.Empty);
        }

        

        public long GetProductCount()
        {
            return _productCollection.CountDocuments(FilterDefinition<Product>.Empty);
        }

      public  async Task<decimal>  GetProductAvgPrice()
        {
            var pipeline =  new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument
                {
                    {"_id",null },
                    {"averagePrice",new BsonDocument("$avg","ProductPrice") },

                })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var value = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return value;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(x => x.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x=>x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(x => x.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }
    }
}
