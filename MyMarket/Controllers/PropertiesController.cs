using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.CategoryService;
using MyMarket.Service.PropertyService;

namespace MyMarket.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly ICategoryService _categoryService;
        public PropertiesController(IPropertyService propertyService, ICategoryService categoryService)
        {
            _propertyService = propertyService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return PartialView("~/Views/Shared/Settings/_Properties.cshtml", await this._propertyService.GetPropertiesWithCategories());
        }

        public IActionResult Properties(List<PropertyViewModel> properties)
        {
            return PartialView("~/Views/Shared/Settings/_Properties.cshtml", properties);
        }

        public async Task<IActionResult> GetProperties()
        {
            return Json(await this._propertyService.GetPropertyViewModels());
        }

        public async Task<IActionResult> GetPropertiesByCategoryId(int categoryId)
        {
            return Json(await this._propertyService.GetPropertiesByCategoryId(categoryId));
        }

        public async Task<PropertyViewModel> GetPropertyById(int id)
        {
            return await this._propertyService.GetPropertyViewModel(id);
        }

        public async Task<IActionResult> Create([FromBody]PropertyViewModel formData)
        {
            await this._propertyService.Create(formData);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Update(PropertyViewModel formData)
        {
            await this._propertyService.Update(formData);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this._propertyService.Delete(id);
            return Json(new { success = true });
        }
    }
}
