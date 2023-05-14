namespace EventSourcing.Api.Features.Handlers.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ProductStream _stream;

        public DeleteProductCommandHandler(ProductStream stream)
        {
            _stream = stream;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _stream.Deleted(request.Id);
            await _stream.SaveAsync();
        }
    }
}
