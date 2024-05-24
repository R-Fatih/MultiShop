using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
	public interface ICargoCompanyService
	{
		Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync();
		Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
		Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
		Task DeleteCargoCompanyAsync(string cargoCompanyId);
		Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(string cargoCompanyId);
	}
}
