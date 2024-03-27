using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]

    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var categories = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var specialOffer = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }
            return Ok(specialOffer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("SpecialOffer added successfully");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("SpecialOffer updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("SpecialOffer deleted succesfully");
        }
      

    }
}
