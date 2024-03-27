using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDto;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCargoCompanies()
        {
            var cargoCompanys =await _cargoCompanyService.TGetAllAsync();
            return Ok(cargoCompanys);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoCompany(int id)
        {
            var cargoCompany =await _cargoCompanyService.TGetByIdAsync(id);
            return Ok(cargoCompany);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.TInsertAsync(new EntityLayer.Concrete.CargoCompany { CargoCompanyName=createCargoCompanyDto.CargoCompanyName});
            return Ok("Created succesfully");
        }
        [HttpPost("Update")]    
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.TUpdateAsync(new EntityLayer.Concrete.CargoCompany {CargoCompanyId=updateCargoCompanyDto.CargoCompanyId, CargoCompanyName = updateCargoCompanyDto.CargoCompanyName });
            return Ok("Updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            var cargoCompany =await _cargoCompanyService.TGetByIdAsync(id);
            await _cargoCompanyService.TDeleteAsync(cargoCompany);
            return Ok("Deleted succesfully");
        }
    }
}
