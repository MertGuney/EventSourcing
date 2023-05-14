namespace EventSourcing.Api.Commonds.Products
{
    public class ChangeProductPriceCommand : IRequest
    {
        public ChangeProductPriceDto ChangeProductPrice { get; set; }
    }
}
