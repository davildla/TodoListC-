using Microsoft.EntityFrameworkCore;
using System.Data;
using TodoList.API.Models.Domain;

namespace TodoList.API.Data
{
    public class TodolistDbContext : DbContext  
    {
        public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId);
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Urgency> Urgency { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> Users_Roles { get; set; }

    }

}
