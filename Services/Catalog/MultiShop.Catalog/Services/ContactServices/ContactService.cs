using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
	public class ContactService: IContactService
	{
		private readonly IMongoCollection<Contact> _contactCollection;
		private readonly IMapper _mapper;

		public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
			_mapper = mapper;
		}

		public async Task CreateContactAsync(CreateContactDto createContactDto)
		{
			var value = _mapper.Map<Contact>(createContactDto);
			await _contactCollection.InsertOneAsync(value);
		}

		public async Task DeleteContactAsync(string contactId)
		{
			await _contactCollection.DeleteOneAsync(x => x.ContactId == contactId);
		}

	

		public async Task<List<ResultContactDto>> GetAllContactAsync()
		{
			var values = await _contactCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultContactDto>>(values);
		}

		public async Task<ResultContactDto> GetByIdContactAsync(string contactId)
		{
			var value = await _contactCollection.Find(x => x.ContactId == contactId).FirstOrDefaultAsync();
			return _mapper.Map<ResultContactDto>(value);
		}

		public Task UpdateContactAsync(UpdateContactDto updateContactDto)
		{
			return _contactCollection.ReplaceOneAsync(x => x.ContactId == updateContactDto.ContactId, _mapper.Map<Contact>(updateContactDto));
		}
	}
	}
