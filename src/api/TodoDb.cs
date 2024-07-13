using Microsoft.EntityFrameworkCore;
using SimpleTodo.Api;

public class TodoDb : DbContext
{
    private static string ConnectionString = "Data Source=todos.db;Password=Password123";
    public TodoDb(DbContextOptions options) : base(options) { }
    public DbSet<TodoItem> Items => Set<TodoItem>();
    public DbSet<TodoList> Lists => Set<TodoList>();
}