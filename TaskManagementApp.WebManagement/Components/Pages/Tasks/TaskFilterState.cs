using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.WebManagement.Components.Pages.Tasks;

public class TaskFilterState
{
    public TaskFilterParameters TaskFilterParameters { get; set; } = new();

    public void Reset()
    {
        TaskFilterParameters = new();
    }
}

public class TaskFilterParameters
{
    public string SearchQuery { get; set; } = string.Empty;
    public Domain.Entities.TaskStatus? Status { get; set; } 
}