namespace Todolist.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string description { get; set; }
        public bool IsComplete { get; set; }
    }
}
