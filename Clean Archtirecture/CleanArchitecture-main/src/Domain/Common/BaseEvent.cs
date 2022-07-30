using MediatR;

namespace CleanArchitecture.Domain.Common;

//we are using Mediator which are apply CQRS (Command and Query Segeration Responsiblity)
public abstract class BaseEvent : INotification
{
}
