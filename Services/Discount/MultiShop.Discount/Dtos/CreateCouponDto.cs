namespace MultiShop.Discount.Dtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
