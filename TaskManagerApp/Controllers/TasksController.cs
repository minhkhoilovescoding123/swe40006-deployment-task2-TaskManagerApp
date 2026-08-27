using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET /Tasks
        public IActionResult Index()
        {
            return View(_taskService.GetAll());
        }

        // GET /Tasks/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST /Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string title, string? description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                ModelState.AddModelError("Title", "Task name is required.");
                return View();
            }

            _taskService.Add(title.Trim(), description);
            return RedirectToAction(nameof(Index));
        }

        // GET /Tasks/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST /Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string? description)
        {
            _taskService.UpdateDescription(id, description);
            return RedirectToAction(nameof(Index));
        }

        // POST /Tasks/UpdateStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, TaskStatusType status)
        {
            _taskService.UpdateStatus(id, status);
            return RedirectToAction(nameof(Index));
        }

        // POST /Tasks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
