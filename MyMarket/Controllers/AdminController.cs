using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Service.CategoryService;

namespace MyMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //private readonly ICategoryService _categoryService;
        public AdminController(ICategoryService categoryService)
        {
            //_categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Admin/Index.cshtml");
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
