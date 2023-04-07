using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.CategoryService;

namespace MyMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        public AdminController(ICategoryService categoryService)
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

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            return PartialView("~/Views/Shared/Settings/_Categories.cshtml", await this._categoryService.GetCategoryViewModels());
        }

        [HttpPost]
        public IActionResult Categories(List<CategoryViewModel> categories)
        {
            return PartialView("~/Views/Shared/Settings/_Categories.cshtml", categories);
        }
    }
}
