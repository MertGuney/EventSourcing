namespace EventSourcing.Api.DTOs.Products
{
    public class ChangeProductNameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
