using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountContext _discountContext;

        public DiscountService(DiscountContext discountContext)
        {
            _discountContext = discountContext;
        }

        public async Task CreateAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _discountContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete From Coupons where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _discountContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<CouponResultDto>> GetAllAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _discountContext.CreateConnection())
            {
                var values = await connection.QueryAsync<CouponResultDto>(query);
                return values.ToList();
            }
        }

        public async Task<CouponResultDto> GetById(int id)
        {
            string query = "Select * from Coupons where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _discountContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CouponResultDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons set Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", updateCouponDto.Id);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _discountContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
