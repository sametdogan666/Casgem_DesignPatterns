using Mediator.Presentation.MediatorPattern.Results;
using MediatR;

namespace Mediator.Presentation.MediatorPattern.Queries;

public record GetProductUpdateByIdQuery : IRequest<GetProductUpdateByIdQueryResult>
{
    public GetProductUpdateByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}