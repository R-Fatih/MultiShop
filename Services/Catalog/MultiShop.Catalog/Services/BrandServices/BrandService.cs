using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
	public class BrandService: IBrandService
	{
		private readonly IMongoCollection<Brand> _brandCollection;
		private readonly IMapper _mapper;

		public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
			_mapper = mapper;
		}

		public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
		{
			var value = _mapper.Map<Brand>(createBrandDto);
			await _brandCollection.InsertOneAsync(value);
		}

		public async Task DeleteBrandAsync(string brandId)
		{
			await _brandCollection.DeleteOneAsync(x => x.BrandId == brandId);
		}

	

		public async Task<List<ResultBrandDto>> GetAllBrandAsync()
		{
			var values = await _brandCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultBrandDto>>(values);
		}

		public async Task<ResultBrandDto> GetByIdBrandAsync(string brandId)
		{
			var value = await _brandCollection.Find(x => x.BrandId == brandId).FirstOrDefaultAsync();
			return _mapper.Map<ResultBrandDto>(value);
		}

		public Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
		{
			return _brandCollection.ReplaceOneAsync(x => x.BrandId == updateBrandDto.BrandId, _mapper.Map<Brand>(updateBrandDto));
		}
	}
	}
