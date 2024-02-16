using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.Models;
using TaskBoard.Core.Services.Interfaces;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext data;

        public BoardService(ApplicationDbContext context)
        {
            this.data = context;
        }
        public async Task<IEnumerable<BoardViewModel>> ShowAllBoardsAsync()
        {
            var boards = await data.Boards
                .AsNoTracking()
                .Select(b=> new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                             .Select(t=> new TaskViewModel()
                             {
                                 Id = t.Id,
                                 Name= t.Title,
                                 Description = t.Description,
                                 Owner = t.Owner.UserName 
                             })
                })
                .ToListAsync();

            return boards;
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


        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
