using Mediator.Presentation.DAL;
using Mediator.Presentation.MediatorPattern.Queries;
using Mediator.Presentation.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Presentation.MediatorPattern.Handlers;

internal sealed class GetProductUpdateByIdQueryHandler : IRequestHandler<GetProductUpdateByIdQuery, GetProductUpdateByIdQueryResult>
{
    private readonly Context _context;

    public GetProductUpdateByIdQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<GetProductUpdateByIdQueryResult> Handle(GetProductUpdateByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Products.FindAsync(request.Id);

        return new GetProductUpdateByIdQueryResult
        {
            Brand = result.Brand,
            Category = result.Category,
            Name = result.Name,
            Price = result.Price,
            Stock = result.Stock,
            Id = result.Id
        };
    }
}