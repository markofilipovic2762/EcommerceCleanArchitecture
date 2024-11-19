﻿using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.Categories.EventHandlers;

public class CategoryCreatedEventHandler : INotificationHandler<CategoryCreatedEvent>
{
    private readonly ILogger<CategoryCreatedEventHandler> _logger;

    public CategoryCreatedEventHandler(ILogger<CategoryCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}