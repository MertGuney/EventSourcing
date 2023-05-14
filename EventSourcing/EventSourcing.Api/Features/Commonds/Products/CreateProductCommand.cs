namespace EventSourcing.Api.Features.Commonds.Products
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductDto CreateProduct { get; set; }
    }
}
