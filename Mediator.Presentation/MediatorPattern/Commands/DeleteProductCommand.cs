using MediatR;

namespace Mediator.Presentation.MediatorPattern.Commands;

public class DeleteProductCommand : IRequest
{
    public DeleteProductCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }

}