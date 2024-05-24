using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
	public class CargoCompanyService : ICargoCompanyService
	{
		private readonly HttpClient _httpClient;

		public CargoCompanyService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("CargoCompanies", createCargoCompanyDto);
		}

		public async Task DeleteCargoCompanyAsync(string cargoCompanyId)
		{
			await _httpClient.GetAsync($"CargoCompanies/delete/{cargoCompanyId}");
		}

		public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<ResultCargoCompanyDto>>("CargoCompanies");
		}

		public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(string cargoCompanyId)
		{
			return await _httpClient.GetFromJsonAsync<UpdateCargoCompanyDto>($"CargoCompanies/{cargoCompanyId}");
		}

		public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			await _httpClient.PostAsJsonAsync<UpdateCargoCompanyDto>("CargoCompanies/Update", updateCargoCompanyDto);
		}
	}
}
