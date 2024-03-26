﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string ProductId)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == ProductId);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<ResultProductDto> GetByIdProductAsync(string ProductId)
        {
            var value =await _productCollection.Find(x => x.ProductId == ProductId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDto>(value);
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            return _productCollection.ReplaceOneAsync(x => x.ProductId == updateProductDto.ProductId, _mapper.Map<Product>(updateProductDto));
        }
    }
}