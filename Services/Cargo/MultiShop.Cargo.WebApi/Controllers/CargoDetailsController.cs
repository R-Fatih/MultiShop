using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDto;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCargoDetails()
        {
            var cargoDetails =await _cargoDetailService.TGetAllAsync();
            return Ok(cargoDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoDetail(int id)
        {
            var cargoDetail =await _cargoDetailService.TGetByIdAsync(id);
            return Ok(cargoDetail);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            await _cargoDetailService.TInsertAsync(new EntityLayer.Concrete.CargoDetail { Barcode=createCargoDetailDto.Barcode,CargoCompanyId=createCargoDetailDto.CargoCompanyId,ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,SenderCustomer=createCargoDetailDto.SenderCustomer});
            return Ok("Created succesfully");
        }
        [HttpPost("Update")]    
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _cargoDetailService.TUpdateAsync(new EntityLayer.Concrete.CargoDetail {CargoDetailId=updateCargoDetailDto.CargoDetailId, Barcode=updateCargoDetailDto.Barcode,CargoCompanyId=updateCargoDetailDto.CargoCompanyId,ReceiverCustomer=updateCargoDetailDto.ReceiverCustomer,SenderCustomer=updateCargoDetailDto.SenderCustomer});
            return Ok("Updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            var cargoDetail =await _cargoDetailService.TGetByIdAsync(id);
            await _cargoDetailService.TDeleteAsync(cargoDetail);
            return Ok("Deleted succesfully");
        }
    }
}
