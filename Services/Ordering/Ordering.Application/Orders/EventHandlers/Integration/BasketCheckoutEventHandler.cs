using BuildingBlocks.Messaging.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Domain.Enums;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler
    (ISender sender,ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>

{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event Handled :{IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }
    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.State, message.EmailAddress, message.AddressLine, message.Country, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
             Id : orderId,
             CustomerId  :  message.CustomerId,
             OrderName :  message.UserName,
             ShippingAddress :  addressDto,
             BillingAddress  :  addressDto,
             Payment:  paymentDto,
             Status:OrderStatus.Pending,
             OrderItems : 
             [
                new OrderItemDto(orderId,new Guid("6EC1297B-EC0A-4AA1-BE25-6726E3B51A27"),2,500),    
                new OrderItemDto(orderId,new Guid("C67D6323-E8B1-4BDF-9A75-B0D0D2E7E914"),1,400)    
             ]);
        return new CreateOrderCommand(orderDto);

    }
}
 