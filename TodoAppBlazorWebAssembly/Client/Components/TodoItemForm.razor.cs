using Microsoft.AspNetCore.Components;
using TodoAppBlazorWebAssembly.Client.Interfaces;
using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Client.Components
{
    public partial class TodoItemForm : ComponentBase
    {
        private NewTodoItemModel _newItem = new NewTodoItemModel();

        [Inject]
        protected ITodoItemDataService TodoItemDataService { get; set; }

        [Parameter]
        public required EventCallback OnItemAdded { get; set; }

        public async Task ItemAdded()
        {
            var result = await TodoItemDataService.CreateTodoItemAsync(_newItem);
            if(result.HasValue)
            {
                _newItem.Text = string.Empty;
                if(OnItemAdded.HasDelegate)
                {
                    await OnItemAdded.InvokeAsync();
                }           
            }              
        }
    }
}