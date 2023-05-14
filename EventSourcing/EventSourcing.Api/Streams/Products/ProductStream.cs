namespace EventSourcing.Api.Streams.Products
{
    public class ProductStream : AbstractStream
    {
        public static string GroupName => "agroup";
        public static string StreamName => "ProductStream";
        public ProductStream(IEventStoreConnection eventStoreConnection) : base(StreamName, eventStoreConnection) { }

        public void Created(CreateProductDto createProduct)
        {
            Events.AddLast(new ProductCreatedEvent()
            {
                Id = Guid.NewGuid(),
                Name = createProduct.Name,
                Price = createProduct.Price,
                Stock = createProduct.Stock,
                UserId = createProduct.UserId
            });
        }

        public void NameChanged(ChangeProductNameDto changeProductName)
        {
            Events.AddLast(new ProductNameChangedEvent()
            {
                Id = changeProductName.Id,
                ChangedName = changeProductName.Name,
            });
        }

        public void PriceChanged(ChangeProductPriceDto changeProductPrice)
        {
            Events.AddLast(new ProductPriceChangedEvent()
            {
                Id = changeProductPrice.Id,
                ChangedPrice = changeProductPrice.Price,
            });
        }

        public void Deleted(Guid id)
        {
            Events.AddLast(new ProductDeletedEvent()
            {
                Id = id,
            });
        }
    }
}
