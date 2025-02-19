namespace TodoAppBlazorWebAssembly.Shared.Models
{
    public record TodoItemModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; }
    }
}