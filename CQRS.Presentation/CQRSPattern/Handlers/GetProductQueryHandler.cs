using System.Collections.Generic;
using System.Linq;
using CQRS.Presentation.CQRSPattern.Results;
using CQRS.Presentation.DAL;

namespace CQRS.Presentation.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var results = _context.Products.Select(x => new GetProductQueryResult()
            {
                Brand = x.Brand,
                Category = x.Category,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                Id = x.Id,
                Stock = x.Stock
            }).ToList();

            return results;
        }
    }
}