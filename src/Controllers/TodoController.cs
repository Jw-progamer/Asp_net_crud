using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Controllers {
    [Route ("api/[controller]")]
    public class TodoController : ControllerBase {

        private readonly TodoContext _context;
        public TodoController (TodoContext context) {
            this._context = context;
        }

        // GET api/todo
        [HttpGet ("")]
        public ActionResult<List<Todo>> GetAll () {
            return _context.TodoItems.ToList ();
        }

        // GET api/todo/5
        [HttpGet ("{id}")]
        public ActionResult<Todo> GetById (long id) {
            var todo = _context.TodoItems.Find (id);
            if (todo == null) {
                return NotFound ();
            }
            return todo;
        }

        // POST api/todo
        [HttpPost ("")]
        public ActionResult<Todo> Post ([FromBody] Todo todo) {
            _context.TodoItems.Add (todo);
            _context.SaveChanges ();
            return CreatedAtAction (nameof (GetById), new { id = todo.id }, todo);
        }

        // PUT api/todo/5
        [HttpPut ("{id}")]
        public ActionResult<Todo> Put (long id, [FromBody] Todo todo) {
            if (id != todo.id) {
                return BadRequest ();
            }

            _context.Entry (todo).State = EntityState.Modified;
            _context.SaveChanges ();

            return NoContent ();
        }

        // DELETE api/todo/5
        [HttpDelete ("{id}")]
        public ActionResult<Todo> Delete (long id) {
            var todoItem = _context.TodoItems.Find (id);
            if (todoItem == null) {
                return NotFound ();
            }

            _context.TodoItems.Remove (todoItem);
            _context.SaveChangesAsync ();

            return todoItem;
        }
    }
}