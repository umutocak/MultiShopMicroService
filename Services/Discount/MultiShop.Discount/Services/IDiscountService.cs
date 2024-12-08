using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<CouponResultDto>> GetAllAsync();
        Task CreateAsync(CreateCouponDto createCouponDto);
        Task UpdateAsync(UpdateCouponDto updateCouponDto);
        Task DeleteAsync(int id);
        Task<CouponResultDto> GetById(int id);
    }
}
