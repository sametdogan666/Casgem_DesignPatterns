using CQRS.Presentation.CQRSPattern.Commands;
using CQRS.Presentation.CQRSPattern.Queries;
using CQRS.Presentation.CQRSPattern.Results;
using CQRS.Presentation.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS.Presentation.CQRSPattern.Handlers
{
    public class GetProductUpdateByIdQueryHandler
    {
        private readonly Context _context;

        public GetProductUpdateByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateByIdQueryResult Handle(GetProductUpdateByIdQuery getProductUpdateByIdQuery)
        {
            var value = _context.Products.Find(getProductUpdateByIdQuery.Id);

            return new GetProductUpdateByIdQueryResult()
            {
                Brand = value.Brand,
                Category = value.Category,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                Id = value.Id,
                Stock = value.Stock
            };
        }
    }
}