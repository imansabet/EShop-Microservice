namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);
public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        // Todo : 
        // Get basket from db
        // basket = _repo.getbasket(request.username)
        return new GetBasketResult(new ShoppingCart("Swn"));
    }
}
