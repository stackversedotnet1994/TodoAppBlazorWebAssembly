using Microsoft.AspNetCore.Mvc;
using TodoAppBlazorWebAssembly.Server.Interfaces;
using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TodoItemModel>))]
        public async Task<IActionResult> Get()
        {
            var data = await _todoService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public async Task<IActionResult> Post(NewTodoItemModel item)
        {
            var newItemID = await _todoService.AddAsync(item);
            return new ObjectResult(newItemID) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPost("{id}/complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Complete(int id)
        {
            await _todoService.CompleteAsync(id);
            return Ok();
        }

        [HttpPost("{id}/uncomplete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Uncomplete(int id)
        {
            await _todoService.UncompleteAsync(id);
            return Ok();
        }
    }
}