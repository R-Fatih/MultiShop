using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCouponsAsync()
        {
            var coupons = await _discountService.GetAllCouponsAsync();
            return Ok(coupons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
        {
            var coupon = await _discountService.GetCouponByIdAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Discount created succesfully.");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Discount updated succesfully.");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCouponAsync(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Discount deleted succesfully.");
        }
        [HttpGet("GetCodeDetailByCode")]
        public async Task<IActionResult> GetCodeDetailByCode(string code)
        {
			var coupon = await _discountService.GetCodeDetailByCode(code);
			if (coupon == null)
            {
				return NotFound();
			}
			return Ok(coupon);
		}

    }
}
