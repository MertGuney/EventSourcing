namespace EventSourcing.Api.Events.Products
{
    public class ProductPriceChangedEvent : IEvent
    {
        public Guid Id { get; set; }
        public decimal ChangedPrice { get; set; }
    }
}
