using Mediator.Presentation.DAL;
using Mediator.Presentation.MediatorPattern.Commands;
using MediatR;


namespace Mediator.Presentation.MediatorPattern.Handlers;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly Context _context;

    public CreateProductCommandHandler(Context context)
    {
        _context = context;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Add(new Product
        {
            Name = request.Name,
            Stock = request.Stock,
            Brand = "Bilinmiyor",
            Price = 0
        });
        await _context.SaveChangesAsync(cancellationToken);
    }
}