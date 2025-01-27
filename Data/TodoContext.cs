using Microsoft.EntityFrameworkCore;

namespace TodoAppApi.Models.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TodoTask>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);
        }
    }
}