namespace EventSourcing.Api.Commonds.Products
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
