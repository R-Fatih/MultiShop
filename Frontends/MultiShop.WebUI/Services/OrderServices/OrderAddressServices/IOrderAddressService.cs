using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
      //  Task<List<ResultOrderAddressDto>> GetAllOrderAddresssAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
      //  Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateOrderAddressDto);
      //  Task DeleteOrderAddressAsync(string OrderAddressId);
       // Task<UpdateOrderAddressDto> GetByIdOrderAddressAsync(string OrderAddressId);
    }
}
