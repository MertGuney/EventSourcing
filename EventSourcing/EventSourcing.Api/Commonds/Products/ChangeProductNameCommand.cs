namespace EventSourcing.Api.Commonds.Products
{
    public class ChangeProductNameCommand : IRequest
    {
        public ChangeProductNameDto ChangeProductName { get; set; }
    }
}
