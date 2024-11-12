using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todolist.Data.Repository;
using Todolist.Model;

namespace Todolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoRepository.GetAllTodosAsync();
            return Ok(todos);
        }

        // GET: api/todo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoRepository.GetTodoByIdAsync(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoItem todoItem)
        {
            if (todoItem == null)
                return BadRequest();

            var createdTodo = await _todoRepository.CreateTodoAsync(todoItem);
            return CreatedAtAction(nameof(GetById), new { id = createdTodo.Id }, createdTodo);
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItem todoItem)
        {   
            var updatedTodo = await _todoRepository.UpdateTodoAsync(id, todoItem);
            if (updatedTodo == null)
                return NotFound();

            return Ok(updatedTodo);
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todoRepository.DeleteTodoAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
