using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Server.Interfaces
{
    public interface ITodoService
    {
        /// <summary>
        /// Get all available TodoItem records
        /// </summary>
        /// <returns>List of TodoItem records</returns>
        Task<List<TodoItemModel>> GetAllAsync();

        /// <summary>
        /// Creates a new TodoItem record
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>ID of the new TodoItem</returns>
        Task<int> AddAsync(NewTodoItemModel item);

        /// <summary>
        /// Marks a specific TodoItem record as complete
        /// </summary>
        /// <param name="id">ID of the TodoItem to complete</param>
        /// <returns>Task</returns>
        Task CompleteAsync(int id);

        /// <summary>
        /// Removes completion status for a specific TodoItem record
        /// </summary>
        /// <param name="id">ID of the TodoItem to uncomplete</param>
        /// <returns>Task</returns>
        Task UncompleteAsync(int id);
    }
}