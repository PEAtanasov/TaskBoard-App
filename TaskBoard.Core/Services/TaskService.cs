using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Core.Models;
using TaskBoard.Core.Services.Interfaces;
using TaskBoard.Infrastructure.Data;
using Task = TaskBoard.Infrastructure.Models.Task;

namespace TaskBoard.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext data;

        public TaskService(ApplicationDbContext context)
        {
            this.data = context;
        }

        public async System.Threading.Tasks.Task CreateAsync(TaskFormModel model)
        {
            var taskToAd = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                OwnerId = model.OwnerId,
                CreatedOn = DateTime.Now
            };

            await data.Tasks.AddAsync(taskToAd);
            await data.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> GetTaskDetailsByIdAsync(int id)
        {
            //navigation properties are included as part of the LINQ query projection. This means that Entity Framework, while executing the query, eagerly loads these navigation properties along with the main entity (Task) using SQL joins or separate queries, depending on your EF configuration (e.g., lazy loading enabled or disabled).

            //var task = await data.Tasks
            //    .Where(t => t.Id == id)
            //    .AsNoTracking()
            //    .Select(task => new TaskDetailsViewModel()
            //    {
            //        Id = task.Id,
            //        Name = task.Title,
            //        Description = task.Description,
            //        CreatedOn = task.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
            //        Owner = task.Owner.UserName,
            //        Board = task.Board.Name
            //    })
            //    .FirstOrDefaultAsync();


            //FirstOrDefaultAsync retrieves only the main entity (Task) 
            var taskToEdit = await data.Tasks
                .AsNoTracking()
                .Include(t=>t.Owner)
                .Include(t=>t.Board)
                .FirstOrDefaultAsync(t => t.Id == id);

            var task = new TaskDetailsViewModel()
            {
                Id = taskToEdit.Id,
                Name = taskToEdit.Title,
                Description = taskToEdit.Description,
                CreatedOn = taskToEdit.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                Owner = taskToEdit.Owner.UserName,
                Board = taskToEdit.Board.Name
            };

            

            return task;               
        }

        public async Task<TaskFormModel> GetTaskFormModelAsync(int id)
        {
            var task = await data.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskFormModel()
                {
                    Id=t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    OwnerId=t.OwnerId,
                    BoardId= t.BoardId
                    
                })
                .FirstOrDefaultAsync();

            var boards = await GetBoardsAsync();
            task.Boards = boards;

            return task;
        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoardsAsync()
        {
            var boards = await data.Boards
                .AsNoTracking()
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();

            return boards;
        }
        
        public async System.Threading.Tasks.Task EditTaskAsync(TaskFormModel model)
        {
            var task = await data.Tasks.FindAsync(model.Id);

            task.Description= model.Description;
            task.Title= model.Title;
            task.BoardId= model.BoardId;

            await data.SaveChangesAsync();      
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            var taskToDelete = await data.Tasks.FindAsync(id);

            if (taskToDelete == null)
            {
                throw new ArgumentException("The task doesn't exist");
            }

            data.Tasks.Remove(taskToDelete);
            await data.SaveChangesAsync();
        }
    }
}
