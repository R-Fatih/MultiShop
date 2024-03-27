using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDto;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCargoCustomers()
        {
            var cargoCustomers =await _cargoCustomerService.TGetAllAsync();
            return Ok(cargoCustomers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoCustomer(int id)
        {
            var cargoCustomer =await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(cargoCustomer);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _cargoCustomerService.TInsertAsync(new EntityLayer.Concrete.CargoCustomer { Address=createCargoCustomerDto.Address,City=createCargoCustomerDto.City,District=createCargoCustomerDto.District,Email=createCargoCustomerDto.Email,Name=createCargoCustomerDto.Name,Phone=createCargoCustomerDto.Phone,Surname=createCargoCustomerDto.Surname});
            return Ok("Created succesfully");
        }
        [HttpPost("Update")]    
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _cargoCustomerService.TUpdateAsync(new EntityLayer.Concrete.CargoCustomer {CargoCustomerId=updateCargoCustomerDto.CargoCustomerId, Address = updateCargoCustomerDto.Address, City = updateCargoCustomerDto.City, District = updateCargoCustomerDto.District, Email = updateCargoCustomerDto.Email, Name = updateCargoCustomerDto.Name, Phone = updateCargoCustomerDto.Phone, Surname = updateCargoCustomerDto.Surname });
            return Ok("Updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            var cargoCustomer =await _cargoCustomerService.TGetByIdAsync(id);
            await _cargoCustomerService.TDeleteAsync(cargoCustomer);
            return Ok("Deleted succesfully");
        }
    }
}
