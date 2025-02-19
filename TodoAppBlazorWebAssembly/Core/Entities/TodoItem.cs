
namespace TodoAppBlazorWebAssembly.Core.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Text { get; set; }
        public bool Completed { get; set; }
    }
}