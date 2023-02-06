using TodoList.API.Models.Domain;

namespace TodoList.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password); // login

        Task<User> RegisterUser(User user);
    }
}
