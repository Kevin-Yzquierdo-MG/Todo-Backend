using Microsoft.EntityFrameworkCore;
using Todolist.Model;

namespace Todolist.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllTodosAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem> CreateTodoAsync(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<TodoItem> UpdateTodoAsync(int id, TodoItem todoItem)
        {
            var existingTodo = await _context.TodoItems.FindAsync(id);
            if (existingTodo == null)
                return null;

            existingTodo.Title = todoItem.Title;
            existingTodo.description = todoItem.description;
            existingTodo.IsComplete = todoItem.IsComplete;

            await _context.SaveChangesAsync();
            return existingTodo;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return false;

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
