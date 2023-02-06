using Microsoft.EntityFrameworkCore;
using TodoList.API.Models.Domain;

namespace TodoList.API.Data
{
    public class TodolistDbContext : DbContext  
    {
        public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options) { }


        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
