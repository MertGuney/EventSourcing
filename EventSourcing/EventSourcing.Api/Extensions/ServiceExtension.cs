namespace EventSourcing.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddEventStore(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = EventStoreConnection.Create(configuration.GetConnectionString("EventStore"));
            connection.ConnectAsync().Wait();

            services.AddSingleton(connection);

            using var logFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddConsole();
            });
            var logger = logFactory.CreateLogger("Startup");

            connection.Connected += (sender, args) =>
            {
                logger.LogInformation("EventStore Connection established.");
            };

            connection.ErrorOccurred += (sender, args) =>
            {
                logger.LogError(args.Exception.Message);
            };
        }
    }
}
