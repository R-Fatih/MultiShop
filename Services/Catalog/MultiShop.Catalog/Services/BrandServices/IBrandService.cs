using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandServices
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GetAllBrandAsync();
		Task CreateBrandAsync(CreateBrandDto createBrandDto);
		Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
		Task DeleteBrandAsync(string featureSliderId);
		Task<ResultBrandDto> GetByIdBrandAsync(string featureSliderId);

	}
}
