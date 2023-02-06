using TodoList.API.Data;
using TodoList.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace TodoList.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodolistDbContext todolistDbContext;

        public UserRepository(TodolistDbContext todolistDbContext)
        {
            this.todolistDbContext = todolistDbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await todolistDbContext.Users.ToListAsync();
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            // gets a user
            var userNameExists = await todolistDbContext.Users
                .FirstOrDefaultAsync(x => x.Username == user.Username);

            if (userNameExists != null)
            { // other user have this username
                return null;
            }
            else
            {
                user.Id = Guid.NewGuid();
                await todolistDbContext.AddAsync(user); // add to db context first
                await todolistDbContext.SaveChangesAsync(); // save db context changes into the database
                return user;
            }        
        }
    }
}
