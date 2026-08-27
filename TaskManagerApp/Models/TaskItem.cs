namespace TaskManagerApp.Models
{
    public enum TaskStatusType
    {
        NotStarted,
        Ongoing,
        Complete,
        Late
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskStatusType Status { get; set; } = TaskStatusType.NotStarted;
    }
}
