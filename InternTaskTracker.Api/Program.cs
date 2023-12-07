using InternTaskTracker.Core.Database;
using InternTaskTracker.Core.Domain;
using InternTaskTracker.Core.Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddCoreDbContext(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Inter task tracker API", Description = "Keep track of your tasks as an intern", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
});

// Automatically redirect to swagger
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.MapGet("/todos", GetAllTodosAsync);
app.MapGet("/todos/{id}", GetTodoAsync);
app.MapPost("/todos", PostTodoAsync);
app.MapDelete("/todos/{id}", DeleteTodoAsync);
// TODO: Add PUT endpoint

app.Run();

static async Task<IResult> GetAllTodosAsync(InternTaskTrackerDbContext db)
{
    var todos = await db.Todos.ToListAsync();
    return Results.Ok(todos);
}

static async Task<IResult> GetTodoAsync(InternTaskTrackerDbContext db, int id)
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null)
        return Results.NotFound();

    return Results.Ok(todo);
}

static async Task<IResult> PostTodoAsync(InternTaskTrackerDbContext db, TodoItem todo)
{
    await db.Todos.AddAsync(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todo/{todo.Id}", todo);
}

static async Task<IResult> DeleteTodoAsync(InternTaskTrackerDbContext db, int id)
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null)
        return Results.NotFound();

    db.Todos.Remove(todo);
    await db.SaveChangesAsync();

    return Results.Ok();
}
