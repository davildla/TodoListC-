using TodoList.API.Data;
using TodoList.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace TodoList.API.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodolistDbContext todolistDbContext;

        public TodoRepository(TodolistDbContext todolistDbContext)
        {
            this.todolistDbContext = todolistDbContext;
        }
        public async Task<Todo> AddTodoAsync(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            await todolistDbContext.AddAsync(todo); // add to db context first
            await todolistDbContext.SaveChangesAsync(); // save db context changes into the database
            return todo;
        }

        public async Task<Todo> DeleteTodoAsync(Guid id)
        {
            var todo = await todolistDbContext.Todos.FirstOrDefaultAsync(item => item.Id == id);

            if (todo == null)
            {
                return null;
            }

            // Delete the item
            todolistDbContext.Todos.Remove(todo);
            await todolistDbContext.SaveChangesAsync();
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await todolistDbContext.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await todolistDbContext.Todos.FirstOrDefaultAsync( item => item.Id == id);
        }

        public async Task<Todo> UpdateTodoAsync(Guid id, Todo update)
        {
            var todo = await todolistDbContext.Todos.FirstOrDefaultAsync(item => item.Id == id);

            if (todo == null)
            {
                return null;
            }
            todo.Title = update.Title;
            todo.Content = update.Content;
            todo.UserId = update.UserId;

            await todolistDbContext.SaveChangesAsync();
            return todo;
        }
    }
}
