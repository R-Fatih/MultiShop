using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string ProductDetailId)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == ProductDetailId);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<ResultProductDetailDto> GetByIdProductDetailAsync(string ProductDetailId)
        {
            var value = await _productDetailCollection.Find(x => x.ProductDetailId == ProductDetailId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDetailDto>(value);
        }

        public Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            return _productDetailCollection.ReplaceOneAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, _mapper.Map<ProductDetail>(updateProductDetailDto));
        }
    }
}
