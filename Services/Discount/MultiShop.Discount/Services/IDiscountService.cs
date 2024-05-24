﻿using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int couponId);
        Task<ResultCouponDto> GetCouponByIdAsync(int couponId);
        Task<ResultCouponDto> GetCodeDetailByCode(string code);
        Task<int> GetDiscountCouponCount();
    }
}
