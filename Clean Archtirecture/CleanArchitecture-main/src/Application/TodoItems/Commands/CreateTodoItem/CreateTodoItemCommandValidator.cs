using FluentValidation;

namespace CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;

//this is the validator that attach to Create ToDoItemCommand that its called by the ValidationBehaviour when apply SaveChagnes()
public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
