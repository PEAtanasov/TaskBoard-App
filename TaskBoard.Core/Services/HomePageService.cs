using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.Models;
using TaskBoard.Core.Services.Interfaces;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Core.Services
{
    public class HomePageService : IHomePageService
    {
        private readonly ApplicationDbContext data;

        public HomePageService(ApplicationDbContext context)
        {
            this.data = context;
        }

        public HomeViewModel GetHomePage(string? userId)
        {
            var taskBoards = data.Boards
                .AsNoTracking()
                .Select(b => b.Name)
                .Distinct();

            var tasksCount = new List<HomeBoardModel> ();

            foreach (var taskBoard in taskBoards)
            {
                var tasksInBoard = data.Tasks
                    .AsNoTracking()
                    .Where(t=>t.Board.Name==taskBoard)
                    .Count();

                tasksCount.Add(new HomeBoardModel()
                {
                    BoardName = taskBoard,
                    TasksCount = tasksInBoard
                });
            }

            var userTaskCount = -1;

            if (userTaskCount!=null)
            {
                userTaskCount = data.Tasks.AsNoTracking().Where(t => t.OwnerId == userId).Count();
            }

            var homePageModel = new HomeViewModel()
            {
                AllTasksCount = data.Tasks.Count(),
                BoardsWithTasksCount = tasksCount,
                UserTasksCount = userTaskCount
            };

            return homePageModel;
        }
    }
}
