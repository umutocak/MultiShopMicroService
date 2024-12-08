﻿namespace MultiShop.Discount.Dtos
{
    public class UpdateCouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
