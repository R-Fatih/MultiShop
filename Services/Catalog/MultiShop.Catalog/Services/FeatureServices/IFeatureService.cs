﻿using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GetAllFeatureAsync();
		Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
		Task DeleteFeatureAsync(string featureId);
		Task<ResultFeatureDto> GetByIdFeatureAsync(string featureId);

	}
}
