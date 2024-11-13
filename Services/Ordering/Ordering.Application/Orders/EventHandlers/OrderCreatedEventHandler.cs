using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Abstractions;

namespace Ordering.Application.Orders.EventHandlers;

public class OrderCreatedEventHandler
    (ILogger<OrderCreatedEventHandler> logger) 
    : INotificationHandler<OrderCreatedEvent>
{
    public  Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event Handled : {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
      
    }
}
