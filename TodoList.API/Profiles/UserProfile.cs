using AutoMapper;

namespace TodoList.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.Domain.User, Models.DTO.User>().ReverseMap();
        }
    }
}
