namespace EventSourcing.Api.Events.Products
{
    public class ProductPriceChangedEvent
    {
        public Guid Id { get; set; }
        public decimal ChangedPrice { get; set; }
    }
}
