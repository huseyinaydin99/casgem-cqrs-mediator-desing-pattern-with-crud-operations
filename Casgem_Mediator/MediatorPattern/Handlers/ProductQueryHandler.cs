using Casgem_Mediator.DAL;
using Casgem_Mediator.MediatorPattern.Queries;
using Casgem_Mediator.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Casgem_Mediator.MediatorPattern.Handlers
{
    public class ProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly Context _context;
        public ProductQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Select(x => new GetProductQueryResult
            {
                Brand = x.Brand,
                Category = x.Category,
                Name = x.Name,
                Price = x.Price,
                ProductID = x.ProductID,
                Stock = x.Stock
            }).AsNoTracking().ToListAsync();
        }
    }
}
