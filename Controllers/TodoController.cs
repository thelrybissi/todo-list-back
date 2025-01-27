using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAppApi.Models;
using TodoAppApi.Models.Data;

namespace TodoAppApi.Controllers
{
    [ApiController]
    [Route("api/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {

        private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var todos = await _context.TodoTasks.Where(t => t.UserId == userId).ToListAsync();
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(TodoTask task)
        {
            task.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, TodoTask updatedTask)
        {
            var todo = await _context.TodoTasks.FindAsync(id);
            if (todo == null) return NotFound();

            todo.Title = updatedTask.Title;
            todo.Description = updatedTask.Description;
            todo.IsCompleted = updatedTask.IsCompleted;

            await _context.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.TodoTasks.FindAsync(id);
            if (todo == null) return NotFound();

            _context.TodoTasks.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}