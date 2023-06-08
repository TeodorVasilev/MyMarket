using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.ListingService;

namespace MyMarket.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingService _listingService;
        public ListingsController(IListingService listingService)
        {
            this._listingService = listingService;
        }

        public async Task<IActionResult> Index(int categoryId = 0)
        {
            var model = await this._listingService.GetListingsByCategoryId(categoryId);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateStore(CreateListingViewModel formData)
        {
            await this._listingService.Create(formData);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Listing(int id)
        {
            return View(await this._listingService.GetListingViewModel(id));
        }
    }
}
