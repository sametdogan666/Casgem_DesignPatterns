namespace Mediator.Presentation.MediatorPattern.Results;

public class GetProductUpdateByIdQueryResult
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public int Stock { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
}