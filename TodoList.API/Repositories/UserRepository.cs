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
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await todolistDbContext.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await todolistDbContext.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await todolistDbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }

        public async Task<User> RegisterUser(User user)
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
