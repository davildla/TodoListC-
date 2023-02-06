using TodoList.API.Models.Domain;

namespace TodoList.API.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetTodoByIdAsync(Guid id);
        Task<Todo> AddTodoAsync(Todo todo);
        Task<Todo> UpdateTodoAsync(Guid id, Todo update);
        Task<Todo> DeleteTodoAsync(Guid id);
    }
}
