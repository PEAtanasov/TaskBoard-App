using TaskBoard.Core.Models;

namespace TaskBoard.Core.Services.Interfaces
{
    public interface ITaskService
    {
        public Task CreateAsync(TaskFormModel model);

        public Task<TaskDetailsViewModel> GetTaskDetailsByIdAsync(int id);

        public Task<TaskFormModel> GetTaskFormModelAsync(int id);

        public Task EditTaskAsync(TaskFormModel model);

        public Task DeleteTaskAsync(int id);
    }
}
