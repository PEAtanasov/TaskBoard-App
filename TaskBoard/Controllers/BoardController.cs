using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Services.Interfaces;

namespace TaskBoard.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService _boardService)
        {
            this.boardService = _boardService;
        }

        public async Task<IActionResult> All()
        {
            var model = await boardService.GetBoardsAsync();
            return View(model);
        }
    }
}
