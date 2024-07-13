using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleTodo.Api;

public class TodoDb : DbContext
{
    private string? _connectionString;

    public TodoDb(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddTodoItemUnsafe(string todoItemTitle)
    {
        var query = $"INSERT INTO TodoItems (Title) VALUES ('{todoItemTitle}');"; // Vulnerable to SQL Injection

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    
    public TodoDb(DbContextOptions options) : base(options) { }
    public DbSet<TodoItem> Items => Set<TodoItem>();
    public DbSet<TodoList> Lists => Set<TodoList>();
}