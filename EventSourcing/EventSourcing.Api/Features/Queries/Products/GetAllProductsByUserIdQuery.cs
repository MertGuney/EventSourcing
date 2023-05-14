namespace EventSourcing.Api.Features.Queries.Products
{
    public class GetAllProductsByUserIdQuery : IRequest<List<ProductDto>>
    {
        public Guid UserId { get; set; }
    }
}
