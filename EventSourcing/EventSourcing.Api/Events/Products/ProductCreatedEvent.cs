using EventSourcing.Api.Events.Common.Interfaces;

namespace EventSourcing.Api.Events.Products
{
    public class ProductCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid UserId { get; set; }
    }
}
