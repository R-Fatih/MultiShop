﻿
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService( IDatabaseSettings _databaseSettings)
        {

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            return await _productCollection.Find(Builders<Product>.Filter.Empty).SortByDescending(p => p.ProductPrice).Project(p => p.ProductName).FirstOrDefaultAsync();
        }

        public async Task<string> GetMinPriceProductName()
        {
            return await _productCollection.Find(Builders<Product>.Filter.Empty).SortBy(p => p.ProductPrice).Project(p => p.ProductName).FirstOrDefaultAsync();
        }

        public async Task<decimal> GetProductAvgPrice()
        {

            var pipeline = new[]
            {
                new BsonDocument("$group",
                                    new BsonDocument
                                    {
                        { "_id", null },
                        { "avgPrice", new BsonDocument("$avg", "$ProductPrice") }
                    })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var avgPrice = result.FirstOrDefault().GetValue("avgPrice").ToDecimal();
            return avgPrice;


        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
