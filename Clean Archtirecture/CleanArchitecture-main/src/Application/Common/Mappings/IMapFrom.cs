using AutoMapper;

namespace CleanArchitecture.Application.Common.Mappings;

//This interface used for any DTO class want to Map to target entity such as public class TodoItemBriefDto : IMapFrom<TodoItem>
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
