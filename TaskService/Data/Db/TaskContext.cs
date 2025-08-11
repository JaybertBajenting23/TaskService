using Microsoft.EntityFrameworkCore;
using TaskService.Data.Models;
using TaskModel = TaskService.Data.Models.TaskModel;

namespace TaskService.Data.Db
{
    public class TaskContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TaskModel> Tasks { get; set; } = null!;


        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasMany(user => user.Tasks)
                .WithOne(task => task.AssignedUser)
                .HasForeignKey(task => task.AssignedUserId);
        }



    }
}
