using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Service.CategoryService;

namespace MyMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        public AdminController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
