using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Client.Interfaces
{
    public interface ITodoItemDataService
    {
        Task<TodoItemModel[]> GetItemsAsync();
        Task<int?> CreateTodoItemAsync(NewTodoItemModel model);
        Task<bool> CompleteTodoItemAsync(int id);
        Task<bool> UncompleteTodoItemAsync(int id);
    }
}