using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
		Task DeleteOfferDiscountAsync(string featureSliderId);
		Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string featureSliderId);

	}
}
