namespace EventSourcing.Api.Features.Commonds.Products
{
    public class ChangeProductPriceCommand : IRequest
    {
        public ChangeProductPriceDto ChangeProductPrice { get; set; }
    }
}
