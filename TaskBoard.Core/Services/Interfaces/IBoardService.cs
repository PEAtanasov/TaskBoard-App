using TaskBoard.Core.Models;

namespace TaskBoard.Core.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<IEnumerable<BoardViewModel>> ShowAllBoardsAsync();

        public Task<IEnumerable<TaskBoardModel>> GetBoardsAsync();

        public Task SaveAsync();
    }

    
}
