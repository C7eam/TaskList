using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Task;
using Task = TaskList.Domain.Entities.Task.Task;
using Microsoft.AspNetCore.Identity;
using TaskList.Authentification;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskList
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           
        }
        public DbSet<Task> Tasks { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tasksdb;Username=postgres;Password=FHqnswff14");
        }
    }
}
