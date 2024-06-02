namespace Catalog.API.Products.CreateProduct;

public record CreatProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreatProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("Created")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Create Product");
    }
}
