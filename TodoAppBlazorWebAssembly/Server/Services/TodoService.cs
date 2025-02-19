using Microsoft.EntityFrameworkCore;
using TodoAppBlazorWebAssembly.Core.Entities;
using TodoAppBlazorWebAssembly.Infrastructure.Data;
using TodoAppBlazorWebAssembly.Server.Interfaces;
using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Server.Services
{
    public class TodoService : ITodoService
    {
        private readonly EFCoreContext _dbContext;

        public TodoService(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<List<TodoItemModel>> GetAllAsync()
        {
            return await _dbContext.TodoItems.Select(_ => new TodoItemModel
            {
                Id = _.ID,
                Text = _.Text,
                Completed = _.Completed
            }).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<int> AddAsync(NewTodoItemModel item)
        {
            var entity = new TodoItem
            {
                Text = item.Text,
                Completed = false
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.ID;
        }

        /// <inheritdoc/>
        public async Task CompleteAsync(int id)
        {
            var entity = await _dbContext.TodoItems.SingleOrDefaultAsync(_ => _.ID == id) ?? throw new KeyNotFoundException();
            entity.Completed = true;
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UncompleteAsync(int id)
        {
            var entity = await _dbContext.TodoItems.SingleOrDefaultAsync(_ => _.ID == id) ?? throw new KeyNotFoundException();
            entity.Completed = false;
            await _dbContext.SaveChangesAsync();
        }
    }
}