using Microsoft.EntityFrameworkCore;

public interface ITodoService {
    Task<IEnumerable<TodoTask>> GetPendingTodos();
    Task MarkAsDone(int id);
}

public class TodoService : ITodoService {
    private readonly TodoContext _db;
    private readonly ILogger _logger;

    public TodoService(TodoContext db, ILogger<TodoService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<TodoTask>> GetPendingTodos() {
        var result = _db.Todos.Where(x => x.DoneWhen == null);
        return await result.ToListAsync();
    }

    public async Task MarkAsDone(int id) {
        var todo = await _db.Todos.FindAsync(id);
        if (todo is not null) {
            todo.DoneWhen = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
    }
}