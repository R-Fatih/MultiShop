using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteSpecialOfferAsync(string featureSliderId);
		Task<ResultSpecialOfferDto> GetByIdSpecialOfferAsync(string featureSliderId);

	}
}
