using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
	public class AboutService: IAboutService
	{
		private readonly IMongoCollection<About> _aboutCollection;
		private readonly IMapper _mapper;

		public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
			_mapper = mapper;
		}

		public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
		{
			var value = _mapper.Map<About>(createAboutDto);
			await _aboutCollection.InsertOneAsync(value);
		}

		public async Task DeleteAboutAsync(string aboutId)
		{
			await _aboutCollection.DeleteOneAsync(x => x.AboutId == aboutId);
		}

	

		public async Task<List<ResultAboutDto>> GetAllAboutAsync()
		{
			var values = await _aboutCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultAboutDto>>(values);
		}

		public async Task<ResultAboutDto> GetByIdAboutAsync(string aboutId)
		{
			var value = await _aboutCollection.Find(x => x.AboutId == aboutId).FirstOrDefaultAsync();
			return _mapper.Map<ResultAboutDto>(value);
		}

		public Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
		{
			return _aboutCollection.ReplaceOneAsync(x => x.AboutId == updateAboutDto.AboutId, _mapper.Map<About>(updateAboutDto));
		}
	}
	}
