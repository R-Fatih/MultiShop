using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
	public class DiscountService : IDiscountService
	{
		private readonly HttpClient _httpClient;

		public DiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<GetDiscountDetailByCode> GetDiscountCode(string code)
		{
			return await _httpClient.GetFromJsonAsync<GetDiscountDetailByCode> ($"Discounts/GetCodeDetailByCode?code={code}");
		}
	}
}
