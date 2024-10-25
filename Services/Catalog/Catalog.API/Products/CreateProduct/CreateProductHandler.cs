using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand
    (string Name,List<string> Category
    ,string Description, string ImageFile
    ,decimal Price) : IRequest<CreateProductResult>;
public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler() : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //business logic to create a product
    }
}
