namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ProductResultDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}
