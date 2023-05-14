namespace EventSourcing.Api.Events.Products
{
    public class ProductDeletedEvent : IEvent
    {
        public Guid Id { get; set; }
    }
}
