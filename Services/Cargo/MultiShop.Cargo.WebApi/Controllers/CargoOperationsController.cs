using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDto;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCargoOperations()
        {
            var cargoOperations =await _cargoOperationService.TGetAllAsync();
            return Ok(cargoOperations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoOperation(int id)
        {
            var cargoOperation =await _cargoOperationService.TGetByIdAsync(id);
            return Ok(cargoOperation);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            await _cargoOperationService.TInsertAsync(new EntityLayer.Concrete.CargoOperation { Barcode=createCargoOperationDto.Barcode,Description=createCargoOperationDto.Description,OperationDate=DateTime.UtcNow.AddHours(3)});
            return Ok("Created succesfully");
        }
        [HttpPost("Update")]    
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _cargoOperationService.TUpdateAsync(new EntityLayer.Concrete.CargoOperation {CargoOperationId=updateCargoOperationDto.CargoOperationId, Barcode = updateCargoOperationDto.Barcode, Description = updateCargoOperationDto.Description, OperationDate = DateTime.UtcNow.AddHours(3)});
            return Ok("Updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            var cargoOperation =await _cargoOperationService.TGetByIdAsync(id);
            await _cargoOperationService.TDeleteAsync(cargoOperation);
            return Ok("Deleted succesfully");
        }
    }
}
