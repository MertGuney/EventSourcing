namespace EventSourcing.Api.Features.Commonds.Products
{
    public class ChangeProductNameCommand : IRequest
    {
        public ChangeProductNameDto ChangeProductName { get; set; }
    }
}
