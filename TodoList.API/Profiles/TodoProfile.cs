using AutoMapper;

namespace TodoList.API.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Models.Domain.Todo, Models.DTO.Todo>().ReverseMap();
        }
    }
}
