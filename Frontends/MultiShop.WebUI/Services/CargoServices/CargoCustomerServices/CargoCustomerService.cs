using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
	public class CargoCustomerService : ICargoCustomerService
	{
		private readonly HttpClient _httpClient;

		public CargoCustomerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<ResultCargoCustomerByIdDto> GetCargoCustomerById(string id)
		{
			return await _httpClient.GetFromJsonAsync<ResultCargoCustomerByIdDto>($"CargoCustomers/GetCargoCustomerById?id={id}");
		}
	}
}
