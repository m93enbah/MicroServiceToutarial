using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace MediatR;

public static class MediatorExtensions
{
    //this will call when you store the TodoItemCreatedEvent event and then call SaveChagnes will used
    //for call DomainEvents that exist on BaseEntity which is used to publish event and then clear the events


    //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
    //_context.TodoItems.Add(entity);
    //await _context.SaveChangesAsync(cancellationToken);
    public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context) 
    {
        var entities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
