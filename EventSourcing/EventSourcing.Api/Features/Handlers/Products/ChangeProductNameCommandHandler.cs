namespace EventSourcing.Api.Features.Handlers.Products
{
    public class ChangeProductNameCommandHandler : IRequestHandler<ChangeProductNameCommand>
    {
        private readonly ProductStream _stream;

        public ChangeProductNameCommandHandler(ProductStream stream)
        {
            _stream = stream;
        }

        public async Task Handle(ChangeProductNameCommand request, CancellationToken cancellationToken)
        {
            _stream.NameChanged(request.ChangeProductName);
            await _stream.SaveAsync();
        }
    }
}
