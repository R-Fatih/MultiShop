using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
	public interface ICargoCustomerService
	{
		Task<ResultCargoCustomerByIdDto> GetCargoCustomerById(string id);
	}
}
