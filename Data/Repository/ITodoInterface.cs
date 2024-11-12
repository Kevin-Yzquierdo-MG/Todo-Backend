using Todolist.Model;

namespace Todolist.Data.Repository
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> GetTodoByIdAsync(int id);
        Task<TodoItem> CreateTodoAsync(TodoItem todoItem);
        Task<TodoItem> UpdateTodoAsync(int id, TodoItem todoItem);
        Task<bool> DeleteTodoAsync(int id);
    }
}
