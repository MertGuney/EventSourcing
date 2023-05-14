namespace EventSourcing.Api.Features.Handlers.Products
{
    public class ChangeProductPriceCommandHandler : IRequestHandler<ChangeProductPriceCommand>
    {
        private readonly ProductStream _stream;

        public ChangeProductPriceCommandHandler(ProductStream stream)
        {
            _stream = stream;
        }

        public async Task Handle(ChangeProductPriceCommand request, CancellationToken cancellationToken)
        {
            _stream.PriceChanged(request.ChangeProductPrice);
            await _stream.SaveAsync();
        }
    }
}
