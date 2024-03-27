using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
		Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
		Task DeleteFeatureSliderAsync(string featureSliderId);
		Task<ResultFeatureSliderDto> GetByIdFeatureSliderAsync(string featureSliderId);
		Task FeatureSliderChangeStatusToTrue(string featureSliderId);
		Task FeatureSliderChangeStatusToFalse(string featureSliderId);
	}
}
