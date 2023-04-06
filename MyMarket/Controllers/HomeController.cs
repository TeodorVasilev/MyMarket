using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.Models;
using MyMarket.Service.PageService.Home;
using System.Diagnostics;

namespace MyMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            this._homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this._homeService.LoadHome());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}