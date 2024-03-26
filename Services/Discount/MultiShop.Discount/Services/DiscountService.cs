using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query="INSERT INTO Coupons(Code,Rate,IsActive,ValidDate) VALUES(@Code,@Rate,@IsActive,@ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);
            await _dapperContext.CreateConnection().ExecuteAsync(query, parameters);
            
        }

        public async Task DeleteCouponAsync(int couponId)
        {
            string query = "DELETE FROM Coupons WHERE CouponId=@CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponId);
            await _dapperContext.CreateConnection().ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "SELECT * FROM Coupons";
            var values= await _dapperContext.CreateConnection().QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(int couponId)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId=@CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponId);
            return await _dapperContext.CreateConnection().QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code=@Code,Rate=@Rate,IsActive=@IsActive,ValidDate=@ValidDate WHERE CouponId=@CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);
            parameters.Add("@CouponId", updateCouponDto.CouponId);
            await _dapperContext.CreateConnection().ExecuteAsync(query, parameters);

        }
    }
}
