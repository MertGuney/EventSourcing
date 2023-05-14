namespace EventSourcing.Api.Features.Handlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly ProductStream _stream;

        public CreateProductCommandHandler(ProductStream stream)
        {
            _stream = stream;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _stream.Created(request.CreateProduct);
            await _stream.SaveAsync();
        }
    }
}
