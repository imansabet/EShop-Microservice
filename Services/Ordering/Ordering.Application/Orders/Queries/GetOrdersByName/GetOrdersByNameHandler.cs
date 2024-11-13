
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Orders.Queries.GetOrderByName;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;
public class GetOrdersByNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
{
    public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        // get orders by name using dbContext
        // return result

        var orders = await dbContext.Orders
                .Include(o => o.OrderItems) 
                .AsNoTracking() //optimization when only reading data : improve performance
                .Where(o => o.OrderName.Value.Contains(query.Name))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);

        return new GetOrdersByNameResult(orders.ToOrderDtoList());
    }
}