using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoard.Core.Models;
using TaskBoard.Core.Services.Interfaces;

namespace TaskBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageService homePageService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHomePageService homePageService)
        {
            _logger = logger;
            this.homePageService = homePageService;
        }

        public IActionResult Index()
        {
            var model = homePageService.GetHomePage(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
