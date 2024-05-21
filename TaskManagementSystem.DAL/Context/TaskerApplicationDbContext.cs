using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.DAL.Context
{
    public class TaskerApplicationDbContext : DbContext
    {
        public TaskerApplicationDbContext(DbContextOptions<TaskerApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Tasker> Taskers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tasker>()
                .Property(x => x.UserId)
                .HasColumnType("NVARCHAR(450)");
        }
    }
}
