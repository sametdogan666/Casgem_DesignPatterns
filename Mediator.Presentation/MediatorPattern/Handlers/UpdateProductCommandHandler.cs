using Mediator.Presentation.DAL;
using Mediator.Presentation.MediatorPattern.Commands;
using MediatR;

namespace Mediator.Presentation.MediatorPattern.Handlers;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly Context _context;

    public UpdateProductCommandHandler(Context context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var value = _context.Products.Find(request.Id);
        value.Brand = request.Brand;
        value.Price = request.Price;
        value.Category = request.Category;
        value.Stock = request.Stock;
        value.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}