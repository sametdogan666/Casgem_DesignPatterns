using CQRS.Presentation.CQRSPattern.Commands;
using CQRS.Presentation.DAL;

namespace CQRS.Presentation.CQRSPattern.Handlers
{
    public class DeleteProductCommandHandler
    {
        private readonly Context _context;

        public DeleteProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeleteProductCommand deleteProductCommand)
        {
            var results = _context.Products.Find(deleteProductCommand.Id);

            _context.Products.Remove(results);
            _context.SaveChanges();
        }
    }
}