using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.TodoItems.EventHandlers;

//this handler that inherit from INotificationHandler accept TodoItemCreatedEvent that contains TodoItem instnace and we can send email notificaiton
public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
