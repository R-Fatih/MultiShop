using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
	public class FeatureSliderService: IFeatureSliderService
	{
		private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
		private readonly IMapper _mapper;

		public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
			await _featureSliderCollection.InsertOneAsync(value);
		}

		public async Task DeleteFeatureSliderAsync(string featureSliderId)
		{
			await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == featureSliderId);
		}

		public Task FeatureSliderChangeStatusToFalse(string featureSliderId)
		{
			throw new NotImplementedException();

		}

		public Task FeatureSliderChangeStatusToTrue(string featureSliderId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
		{
			var values = await _featureSliderCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureSliderDto>>(values);
		}

		public async Task<ResultFeatureSliderDto> GetByIdFeatureSliderAsync(string featureSliderId)
		{
			var value = await _featureSliderCollection.Find(x => x.FeatureSliderId == featureSliderId).FirstOrDefaultAsync();
			return _mapper.Map<ResultFeatureSliderDto>(value);
		}

		public Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			return _featureSliderCollection.ReplaceOneAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, _mapper.Map<FeatureSlider>(updateFeatureSliderDto));
		}
	}
	}
