using Mediator.Presentation.DAL;
using Mediator.Presentation.MediatorPattern.Queries;
using Mediator.Presentation.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Presentation.MediatorPattern.Handlers;

internal sealed class GetProductHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
{
    private readonly Context _context;

    public GetProductHandler(Context context)
    {
        _context = context;
    }

    public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.Select(x => new GetProductQueryResult
        {
            Brand = x.Brand,
            Category = x.Category,
            Name = x.Name,
            Price = x.Price,
            Id = x.Id,
            Stock = x.Stock
        }).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }
}