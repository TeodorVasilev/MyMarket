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

        public IActionResult Index()
        {
            return View();
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
            var model = await this._listingService.GetListingViewModel(id);
            return View(model);
        }
    }
}
