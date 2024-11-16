using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Abstractions;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler
    (IPublishEndpoint publishEndpoint ,ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event Handled : {DomainEvent}", domainEvent.GetType().Name);
        var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);

            
    }
}
