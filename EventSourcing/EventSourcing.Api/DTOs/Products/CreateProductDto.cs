namespace EventSourcing.Api.DTOs.Products
{
    public class CreateProductDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
