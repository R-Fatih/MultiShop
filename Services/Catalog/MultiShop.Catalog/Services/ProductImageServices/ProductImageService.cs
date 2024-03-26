using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;

using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string ProductImageId)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == ProductImageId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<ResultProductImageDto> GetByIdProductImageAsync(string ProductImageId)
        {
            var value = await _productImageCollection.Find(x => x.ProductImageId == ProductImageId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductImageDto>(value);
        }

        public Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            return _productImageCollection.ReplaceOneAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, _mapper.Map<ProductImage>(updateProductImageDto));
        }
    }
}
