using CQRS.Presentation.CQRSPattern.Queries;
using CQRS.Presentation.CQRSPattern.Results;
using CQRS.Presentation.DAL;
using Microsoft.CodeAnalysis;

namespace CQRS.Presentation.CQRSPattern.Handlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly Context _context;

        public GetProductByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIdQueryResult Handle(GetProductByIdQuery getProductByIdQuery)
        {
            var values = _context.Products.Find(getProductByIdQuery.Id);

            return new GetProductByIdQueryResult
            {
                ProductId = values.Id,
                ProductName = values.ProductName,
                ProductBrand = values.Brand
            };
        }
    }
}