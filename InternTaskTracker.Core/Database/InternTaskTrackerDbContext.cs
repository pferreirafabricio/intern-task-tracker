using InternTaskTracker.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace InternTaskTracker.Core.Database;

public class InternTaskTrackerDbContext : DbContext
{
    public InternTaskTrackerDbContext(DbContextOptions options) : base(options) { }
    public DbSet<TodoItem> Todos { get; set; }
}
