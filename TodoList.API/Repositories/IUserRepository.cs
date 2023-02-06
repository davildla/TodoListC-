using TodoList.API.Models.Domain;

namespace TodoList.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> RegisterUserAsync(User user);
    }
}
