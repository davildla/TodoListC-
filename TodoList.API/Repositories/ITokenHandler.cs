using TodoList.API.Models.Domain;

namespace TodoList.API.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
