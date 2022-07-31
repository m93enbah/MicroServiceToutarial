namespace CleanArchitecture.Domain.Events;


//this events are called by the query / commands like CreateTodoItemCommand and then there is an event handler how is consume the events like TodoItemCreatedEventHandler which can execute antother operaiton

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
