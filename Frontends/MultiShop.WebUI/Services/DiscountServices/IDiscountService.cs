﻿using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
	public interface IDiscountService
	{
		Task<GetDiscountDetailByCode> GetDiscountCode(string code);
	}
}
