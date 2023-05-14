using EventSourcing.Api.Data;
using EventSourcing.Api.Features.Queries.Products;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Api.Features.Handlers.Products
{
    public class GetAllProductsByUserIdQueryHandler : IRequestHandler<GetAllProductsByUserIdQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;

        public GetAllProductsByUserIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => x.UserId == request.UserId).Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                UserId = request.UserId,
            }).ToListAsync();
        }
    }
}
