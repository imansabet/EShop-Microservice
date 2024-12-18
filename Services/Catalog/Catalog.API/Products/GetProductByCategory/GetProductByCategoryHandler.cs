﻿
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler
    (IDocumentSession Session) 
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await Session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}
 