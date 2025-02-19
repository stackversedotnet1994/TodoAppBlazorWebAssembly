using Microsoft.EntityFrameworkCore;
using TodoAppBlazorWebAssembly.Core.Entities;
using TodoAppBlazorWebAssembly.Infrastructure.Data.Configurations;

namespace TodoAppBlazorWebAssembly.Infrastructure.Data
{
    public class EFCoreContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemConfiguration());
        }
    }
}