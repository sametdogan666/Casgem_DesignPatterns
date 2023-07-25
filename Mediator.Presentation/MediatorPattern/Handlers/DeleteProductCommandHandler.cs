using Mediator.Presentation.DAL;
using Mediator.Presentation.MediatorPattern.Commands;
using MediatR;

namespace Mediator.Presentation.MediatorPattern.Handlers;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly Context _context;

    public DeleteProductCommandHandler(Context context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var value =  await _context.Products.FindAsync(request.Id);
        _context.Products.Remove(value);
        await _context.SaveChangesAsync(cancellationToken);
    }
}