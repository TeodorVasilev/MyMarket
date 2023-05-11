using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.PropertyService;

namespace MyMarket.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Properties()
        {
            return PartialView("~/Views/Shared/Settings/_Properties.cshtml", await this._propertyService.GetPropertyViewModels());
        }

        public IActionResult Properties(List<PropertyViewModel> properties)
        {
            return PartialView("~/Views/Shared/Settings/_Properties.cshtml", properties);
        }

        public async Task<PropertyViewModel> GetPropertyById(int id)
        {
            return await this._propertyService.GetPropertyViewModel(id);
        }

        public async Task<IActionResult> Create(PropertyViewModel formData)
        {
            await this._propertyService.Create(formData);
            return CreatedAtAction(nameof(GetPropertyById), new { id = formData.Id }, formData);
        }

        public async Task<IActionResult> Update(PropertyViewModel formData)
        {
            await this._propertyService.Update(formData);
            return NoContent();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this._propertyService.Delete(id);
            return NoContent();
        }
    }
}
