namespace EventSourcing.Api.Commonds.Products
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductDto CreateProduct { get; set; }
    }
}
