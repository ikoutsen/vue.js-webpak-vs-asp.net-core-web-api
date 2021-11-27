using Microsoft.EntityFrameworkCore;

namespace TaskManagetWebAPI.Model {
    public class TaskContext : DbContext {
        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TaskState> TaskState { get; set; }
        public TaskContext(DbContextOptions<TaskContext> options) :
            base(options) {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Task>()
                .HasOne(ticket => ticket.CreatorUser)
                .WithMany(user => user.CreatorTasks)
                .HasForeignKey(tiket => tiket.CreatorUserId);

            modelBuilder.Entity<Task>()
                .HasOne(ticket => ticket.WorkerUser)
                .WithMany(user => user.WorkerTasks)
                .HasForeignKey(ticket => ticket.WorkerUserId);
        }
    }
}
