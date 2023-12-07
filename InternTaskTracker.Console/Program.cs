using InternTaskTracker.Core.Database;
using InternTaskTracker.Core.Domain;
using InternTaskTracker.Core.Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddCoreDbContext();

var serviceProvider = services.BuildServiceProvider();
var dbContext = serviceProvider.GetService<InternTaskTrackerDbContext>();

Console.WriteLine("Welcome to the Todo List App!");
Console.WriteLine("Your OS is: " + GetGreetingByOs());

while (true)
{
    ShowMenu();

    var choiceRaw = Console.ReadLine() ?? "";
    _ = Enum.TryParse(choiceRaw, out TodoChoice choice);

    await ChoiceHandler(choice);
}

async Task ChoiceHandler(TodoChoice choice)
{
    switch (choice)
    {
        case TodoChoice.Add:
            await AddTask();
            break;
        case TodoChoice.Remove:
            await RemoveTask();
            break;
        case TodoChoice.MarkAsCompleted:
            await MarkAsCompleted();
            break;
        case TodoChoice.View:
            await ViewTasks();
            break;
        case TodoChoice.Exit:
            Exit();
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            break;
    }
}

async Task AddTask()
{
    Console.Write("Enter task description: ");
    string description = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(description))
    {
        Console.WriteLine("Invalid description. Please enter a valid description.");
        await AddTask();
        return;
    }

    await dbContext!.Todos.AddAsync(new TodoItem(description));
    await dbContext!.SaveChangesAsync();
    Console.WriteLine("Task added successfully!");
}

async Task RemoveTask()
{
    if (!await dbContext!.Todos.AnyAsync())
    {
        Console.WriteLine("No tasks to remove. Todo list is empty.");
        return;
    }

    Console.WriteLine("Tasks in the Todo List:");
    await DisplayTasks();

    Console.Write("Enter the id of the task to remove: ");

    if (int.TryParse(Console.ReadLine(), out int id) && id >= 0)
    {
        var task = await dbContext!.Todos.FindAsync(id);

        if (task is null)
        {
            Console.WriteLine("Invalid id, task not found. Please enter a valid id.");
            return;
        }

        dbContext!.Todos.Remove(task);
        await dbContext!.SaveChangesAsync();

        Console.WriteLine("Task removed successfully!");
        return;
    }

    Console.WriteLine("Invalid id. Please enter a valid id.");
}

async Task MarkAsCompleted()
{
    if (!await dbContext!.Todos.AnyAsync())
    {
        Console.WriteLine("No tasks to mark as completed. Todo list is empty.");
        return;
    }

    Console.WriteLine("Tasks in the Todo List:");
    await DisplayTasks();

    Console.Write("Enter the id of the task to mark as completed: ");

    if (int.TryParse(Console.ReadLine(), out int id) && id >= 0)
    {
        var task = await dbContext!.Todos.FindAsync(id);

        if (task is null)
        {
            Console.WriteLine("Invalid id, task not found. Please enter a valid id.");
            return;
        }

        task.IsComplete = true;
        await dbContext!.SaveChangesAsync();

        Console.WriteLine("Task marked as completed!");
        return;
    }

    Console.WriteLine("Invalid id. Please enter a valid id.");

}

async Task ViewTasks()
{
    if (!await dbContext!.Todos.AnyAsync())
    {
        Console.WriteLine("No tasks in the Todo List. It's empty.");
        return;
    }

    Console.WriteLine("Tasks in the Todo List:");
    await DisplayTasks();
}

async Task DisplayTasks()
{
    var todos = await dbContext!.Todos.ToListAsync();

    foreach (var todo in todos)
        Console.WriteLine($"{todo.Id} - {todo.Description} - {(todo.IsComplete ? "Completed" : "Not Completed")}");
}

static void Exit()
{
    Console.WriteLine("Exiting the Todo List App. Goodbye!");
    Environment.Exit(0);
}

static void ShowMenu()
{
    Console.WriteLine("\n=====================================");
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Remove Task");
    Console.WriteLine("3. Mark Task as Completed");
    Console.WriteLine("4. View Tasks");
    Console.WriteLine("5. Exit");
    Console.WriteLine("=====================================\n");

    Console.Write("\nEnter your choice (1-5): ");
}

static string GetGreetingByOs()
{
    var os = Environment.OSVersion.Platform;
    return os switch
    {
        PlatformID.Win32NT => "Windows",
        PlatformID.Unix => "Linux",
        PlatformID.MacOSX => "MacOS",
        _ => "Unknown"
    };
}
