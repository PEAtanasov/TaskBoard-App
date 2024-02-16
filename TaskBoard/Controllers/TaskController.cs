using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoard.Core.Models;
using TaskBoard.Core.Services;
using TaskBoard.Core.Services.Interfaces;

namespace TaskBoard.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IBoardService boardService;

        public TaskController(ITaskService _taskService, IBoardService boardService)
        {
            this.taskService = _taskService;
            this.boardService = boardService;

        }

        public async Task<IActionResult> Create()
        {
            var boards = await boardService.GetBoardsAsync();

            var model = new TaskFormModel()
            {
                Boards= boards
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            var boards = await boardService.GetBoardsAsync();
            if (!boards.Any(bo=>bo.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Boards = boards;
                return View(model);
            }

            var taskModel = new TaskFormModel()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                OwnerId = GetUserId(),
            };

            await taskService.CreateAsync(taskModel);

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await taskService.GetTaskDetailsByIdAsync(id);

            if (model==null)
            {
                return BadRequest();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var taskToEdit = await taskService.GetTaskFormModelAsync(id);

            if (taskToEdit==null)
            {
                return BadRequest();
            }

            if (User==null || GetUserId()!=taskToEdit.OwnerId)
            {
                return Unauthorized();
            }

            return View(taskToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            var task = await taskService.GetTaskFormModelAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if (GetUserId()!=task.OwnerId)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                var boards = await boardService.GetBoardsAsync();
                task.Boards = boards;
                return View(task);
            }

            await taskService.EditTaskAsync(model);

            return RedirectToAction("All", "Board");
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await taskService.GetTaskFormModelAsync(id);

            if (task==null)
            {
                return BadRequest();
            }

            if (GetUserId() != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskToDelete = new TaskViewModel()
            {
                Id = task.Id,
                Name = task.Title,
                Description = task.Description,
            };

            return View(taskToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            var task = await taskService.GetTaskFormModelAsync(model.Id);

            if (task==null)
            {
                return BadRequest();
            }

            if (GetUserId()!=task.OwnerId)
            {
                return Unauthorized();
            }
            try
            {
                await taskService.DeleteTaskAsync(model.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }


            return RedirectToAction("All", "Board");
        }


        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
