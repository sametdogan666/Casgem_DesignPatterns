using CQRS.Presentation.CQRSPattern.Commands;
using CQRS.Presentation.DAL;

namespace CQRS.Presentation.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand createProductCommand)
        {
            _context.Products.Add(new Product()
            {
                Brand = createProductCommand.Brand,
                Category = createProductCommand.Category,
                ProductName = createProductCommand.ProductName,
                ProductPrice = createProductCommand.ProductPrice,
                Stock = createProductCommand.Stock
            });

            _context.SaveChanges();
        }
    }
}