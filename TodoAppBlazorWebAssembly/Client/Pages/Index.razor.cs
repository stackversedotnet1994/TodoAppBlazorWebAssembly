using Microsoft.AspNetCore.Components;
using TodoAppBlazorWebAssembly.Shared.Models;
using TodoAppBlazorWebAssembly.Client.Interfaces;

namespace TodoAppBlazorWebAssembly.Client.Pages
{
    public partial class Index : ComponentBase
    {
        private TodoItemModel[] _todoItems;

        [Inject]
        protected ITodoItemDataService TodoItemDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _todoItems = await LoadItemsAsync();
        }

        private async Task<TodoItemModel[]> LoadItemsAsync()
        {
            return await  TodoItemDataService.GetItemsAsync();
        }

        public async Task ItemsChanged()
        {
            _todoItems = await LoadItemsAsync();
            StateHasChanged();
        }

        public async Task CompleteItem(TodoItemModel item)
        {
            if(await TodoItemDataService.CompleteTodoItemAsync(item.Id))
            {
                await ItemsChanged();
            }          
        }

        public async Task UncompleteItem(TodoItemModel item)
        {
            if(await TodoItemDataService.UncompleteTodoItemAsync(item.Id))
            {
                await ItemsChanged();
            }          
        }

        public static string ItemClass(TodoItemModel item)
        {
            return item.Completed ? "item-completed" : "";
        }
    }
}