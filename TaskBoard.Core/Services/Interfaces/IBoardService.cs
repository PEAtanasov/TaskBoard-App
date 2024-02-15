using TaskBoard.Core.Models;

namespace TaskBoard.Core.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<IEnumerable<BoardViewModel>> GetBoardsAsync();

        public Task SaveAsync();
    }

    
}
