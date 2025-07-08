using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MyTask> MyTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MyTask>()
                .Property(t => t.Status)
                .HasConversion<string>();
        }

    }
}
