using System.Net.Http.Json;
using TodoAppBlazorWebAssembly.Client.Interfaces;
using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Client.Services
{
    public class TodoItemDataService : ITodoItemDataService
    {
        private readonly HttpClient _httpClient;

        public TodoItemDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TodoItemModel[]> GetItemsAsync()
        {
           using var response = await _httpClient.GetAsync($"api/Todo");
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TodoItemModel[]>();
            }

            return default;
        }

        public async Task<int?> CreateTodoItemAsync(NewTodoItemModel model)
        {
           using var response = await _httpClient.PostAsJsonAsync("api/Todo", model);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }
                
            return default;
        }

        public async Task<bool> CompleteTodoItemAsync(int id)
        {
            using var response = await _httpClient.PostAsync($"api/Todo/{id}/complete", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UncompleteTodoItemAsync(int id)
        {
            using var response = await _httpClient.PostAsync($"api/Todo/{id}/uncomplete", null);
            return response.IsSuccessStatusCode;
        }
    }
}
