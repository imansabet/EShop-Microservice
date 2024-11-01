﻿namespace Catalog.API.Products.GetProducts;

public record GetProductRquest(int? PageNumber = 1 , int? PageSize = 10);
public record GetProductResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductRquest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductResponse>();
            return Results.Ok(response);
        })
            .WithName("GetProducts")
            .Produces<GetProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}
