using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAppBlazorWebAssembly.Core.Entities;
using TodoAppBlazorWebAssembly.Shared;

namespace TodoAppBlazorWebAssembly.Infrastructure.Data.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(Constants.MaxTodoItemLength);
        }
    }
}