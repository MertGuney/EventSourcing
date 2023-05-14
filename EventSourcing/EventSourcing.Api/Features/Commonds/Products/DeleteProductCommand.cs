namespace EventSourcing.Api.Features.Commonds.Products
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
