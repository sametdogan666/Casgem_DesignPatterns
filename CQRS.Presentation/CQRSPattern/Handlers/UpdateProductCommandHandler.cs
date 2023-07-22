using CQRS.Presentation.CQRSPattern.Commands;
using CQRS.Presentation.DAL;

namespace CQRS.Presentation.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand updateProductCommand)
        {
            var result = _context.Products.Find(updateProductCommand.Id);

            result.ProductName = updateProductCommand.ProductName;
            result.Brand = updateProductCommand.Brand;
            result.Category = updateProductCommand.Category;
            result.ProductPrice = updateProductCommand.ProductPrice;
            result.Stock = updateProductCommand.Stock;

            _context.SaveChanges();
        }
    }
}