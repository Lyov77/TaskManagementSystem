using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.DAL.Context
{
    public class TaskerApplicationDbContext : DbContext
    {
        public TaskerApplicationDbContext(DbContextOptions<TaskerApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tasker> Taskers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
