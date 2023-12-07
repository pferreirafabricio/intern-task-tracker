namespace InternTaskTracker.Core.Domain;

public class TodoItem
{
    public TodoItem(string description, bool isComplete = false)
    {
        Description = description;
        IsComplete = isComplete;
    }

    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
}
