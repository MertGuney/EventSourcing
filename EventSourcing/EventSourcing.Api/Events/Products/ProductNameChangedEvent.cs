namespace EventSourcing.Api.Events.Products
{
    public class ProductNameChangedEvent
    {
        public Guid Id { get; set; }
        public string ChangedName { get; set; }
    }
}
