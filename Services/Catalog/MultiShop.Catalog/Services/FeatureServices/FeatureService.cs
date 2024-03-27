using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
	public class FeatureService: IFeatureService
	{
		private readonly IMongoCollection<Feature> _featureCollection;
		private readonly IMapper _mapper;

		public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
		{
			var value = _mapper.Map<Feature>(createFeatureDto);
			await _featureCollection.InsertOneAsync(value);
		}

		public async Task DeleteFeatureAsync(string featureId)
		{
			await _featureCollection.DeleteOneAsync(x => x.FeatureId == featureId);
		}

		

		public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
		{
			var values = await _featureCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureDto>>(values);
		}

		public async Task<ResultFeatureDto> GetByIdFeatureAsync(string featureId)
		{
			var value = await _featureCollection.Find(x => x.FeatureId == featureId).FirstOrDefaultAsync();
			return _mapper.Map<ResultFeatureDto>(value);
		}

		public Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
		{
			return _featureCollection.ReplaceOneAsync(x => x.FeatureId == updateFeatureDto.FeatureId, _mapper.Map<Feature>(updateFeatureDto));
		}
	}
	}
