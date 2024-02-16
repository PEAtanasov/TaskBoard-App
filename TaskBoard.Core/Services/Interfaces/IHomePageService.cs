using TaskBoard.Core.Models;

namespace TaskBoard.Core.Services.Interfaces
{
    public interface IHomePageService
    {
        public HomeViewModel GetHomePage(string? userId);
    }
}
