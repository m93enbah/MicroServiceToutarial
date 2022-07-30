using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Common;

//with BaseEntity its include the BaseEvent which is called the target service that under folder Events (TodoItemCompletedEvent,TodoItemCreatedEvent,TodoItemDeletedEvent)
//based on Properety Change on Child Entity called TodoItem public bool Done
public abstract class BaseEntity
{
    public int Id { get; set; }

    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
