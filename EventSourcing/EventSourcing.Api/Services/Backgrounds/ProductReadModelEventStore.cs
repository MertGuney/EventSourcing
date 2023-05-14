using EventSourcing.Api.Data;
using EventSourcing.Api.Data.Models;

namespace EventSourcing.Api.Services.Backgrounds
{
    public class ProductReadModelEventStore : BackgroundService
    {
        private readonly IEventStoreConnection _connection;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ProductReadModelEventStore> _logger;

        public ProductReadModelEventStore(IEventStoreConnection connection, IServiceProvider serviceProvider, ILogger<ProductReadModelEventStore> logger)
        {
            _connection = connection;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _connection.ConnectToPersistentSubscriptionAsync(ProductStream.StreamName, ProductStream.GroupName, EventAppeared, autoAck: false);
        }

        private async Task EventAppeared(EventStorePersistentSubscriptionBase arg1, ResolvedEvent arg2)
        {
            _logger.LogInformation("The message processing...");

            //var type = Type.GetType($"{Encoding.UTF8.GetString(arg2.Event.Metadata)}, asd.shared");

            var type = Type.GetType($"{Encoding.UTF8.GetString(arg2.Event.Metadata)}");

            var eventData = Encoding.UTF8.GetString(arg2.Event.Data);

            var @event = JsonSerializer.Deserialize(eventData, type);

            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            Product product = null;

            switch (@event)
            {
                case ProductCreatedEvent productCreatedEvent:
                    product = new()
                    {
                        Id = productCreatedEvent.Id,
                        Name = productCreatedEvent.Name,
                        Price = productCreatedEvent.Price,
                        Stock = productCreatedEvent.Stock,
                        UserId = productCreatedEvent.UserId,
                    };
                    await context.Products.AddAsync(product);
                    break;
                case ProductNameChangedEvent productNameChangedEvent:
                    product = await context.Products.FindAsync(productNameChangedEvent.Id);
                    if (product is not null)
                    {
                        product.Name = productNameChangedEvent.ChangedName;
                        context.Products.Update(product);
                    }
                    break;
                case ProductPriceChangedEvent productPriceChangedEvent:
                    product = await context.Products.FindAsync(productPriceChangedEvent.Id);
                    if (product is not null)
                    {
                        product.Price = productPriceChangedEvent.ChangedPrice;
                        context.Products.Update(product);
                    }
                    break;
                case ProductDeletedEvent productDeletedEvent:
                    product = await context.Products.FindAsync(productDeletedEvent.Id);
                    if (product is not null)
                    {
                        context.Products.Remove(product);
                    }
                    break;
            }

            await context.SaveChangesAsync();

            arg1.Acknowledge(arg2.Event.EventId);
        }
    }
}
