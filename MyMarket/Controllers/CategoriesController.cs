using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.CategoryService;

namespace MyMarket.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return PartialView("~/Views/Shared/Settings/_Categories.cshtml", await this._categoryService.GetCategoryViewModels());
        }

        public IActionResult Categories(List<CategoryViewModel> categories)
        {
            return PartialView("~/Views/Shared/Settings/_Categories.cshtml", categories);
        }

        public async Task<IActionResult> GetParentCategories()
        {
            return Json(await this._categoryService.GetParentCategoriesViewModels());
        }

        public async Task<IActionResult> GetChildCategories(int parentId)
        {
            return Json(await this._categoryService.GetChildCategoriesViewModels(parentId));
        }

        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            return await this._categoryService.GetCategoryViewModel(id);
        }

        public async Task<IActionResult> Create([FromBody]CategoryViewModel formData)
        {
            await this._categoryService.Create(formData);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Update(CategoryViewModel formData)
        {
            await this._categoryService.Update(formData);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this._categoryService.Delete(id);
            return Json(new { success = true });
        }
    }
}
