using Microsoft.EntityFrameworkCore;
namespace src.Models {
    public class TodoContext : DbContext {
        public TodoContext (DbContextOptions<TodoContext> options) : base (options) { }
        public DbSet<Todo> TodoItems { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}