using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.OptionService;

namespace MyMarket.Controllers
{
    public class OptionsController : Controller
    {
        private readonly IOptionService _optionService;
        public OptionsController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public async Task<IActionResult> Index()
        {
            return PartialView("~/Views/Shared/Settings/_Options.cshtml", await this._optionService.GetOptionViewModels());
        }

        public IActionResult Options(List<StaticOptionViewModel> options)
        {
            return PartialView("~/Views/Shared/Settings/_Options.cshtml", options);
        }

        public async Task<StaticOptionViewModel> GetOptionById(int id)
        {
            return await this._optionService.GetOptionViewModel(id);
        }

        public async Task<IActionResult> Create([FromBody] StaticOptionViewModel formData)
        {
            await this._optionService.Create(formData);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Update(StaticOptionViewModel formData)
        {
            await this._optionService.Update(formData);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this._optionService.Delete(id);
            return Json(new { success = true });
        }
    }
}
