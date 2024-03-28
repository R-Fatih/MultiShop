﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
	public class OfferDiscountService: IOfferDiscountService
	{
		private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
		private readonly IMapper _mapper;

		public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
			_mapper = mapper;
		}

		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
			await _offerDiscountCollection.InsertOneAsync(value);
		}

		public async Task DeleteOfferDiscountAsync(string offerDiscountId)
		{
			await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == offerDiscountId);
		}

		public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
		{
			var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultOfferDiscountDto>>(values);
		}

		public async Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string offerDiscountId)
		{
			var value = await _offerDiscountCollection.Find(x => x.OfferDiscountId == offerDiscountId).FirstOrDefaultAsync();
			return _mapper.Map<ResultOfferDiscountDto>(value);
		}

		public Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			return _offerDiscountCollection.ReplaceOneAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, _mapper.Map<OfferDiscount>(updateOfferDiscountDto));
		}
	}
	}
