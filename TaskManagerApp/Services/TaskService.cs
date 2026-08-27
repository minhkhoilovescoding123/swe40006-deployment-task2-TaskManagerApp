using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    // Simple in-memory store. Registered as a Singleton in Program.cs so the
    // same list survives across requests for the lifetime of the app.
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAll() => _tasks;

        public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public TaskItem Add(string title, string? description)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = title,
                Description = description,
                Status = TaskStatusType.NotStarted
            };
            _tasks.Add(task);
            return task;
        }

        public bool UpdateDescription(int id, string? description)
        {
            var task = GetById(id);
            if (task == null) return false;
            task.Description = description;
            return true;
        }

        public bool UpdateStatus(int id, TaskStatusType status)
        {
            var task = GetById(id);
            if (task == null) return false;
            task.Status = status;
            return true;
        }

        public bool Delete(int id)
        {
            var task = GetById(id);
            if (task == null) return false;
            _tasks.Remove(task);
            return true;
        }
    }
}
