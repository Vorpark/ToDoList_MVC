using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
