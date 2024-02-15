using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Services.Interfaces;

namespace TaskBoard.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            this.taskService = _taskService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
