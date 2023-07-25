using Mediator.Presentation.MediatorPattern.Results;
using MediatR;

namespace Mediator.Presentation.MediatorPattern.Queries;

public record GetProductQuery : IRequest<List<GetProductQueryResult>>
{

}