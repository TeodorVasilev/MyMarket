using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.DAL.ViewModels.Pages.Home;
using MyMarket.Service.CategoryService;
using MyMarket.Service.ListingService;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.PageService.Home
{
    public class HomeService : IHomeService
    {
        private readonly ICategoryService _categoryService;
        private readonly IListingService _listingService;

        public HomeService(ICategoryService categoryService, IListingService listingService)
        {
            this._categoryService = categoryService;
            this._listingService = listingService;
        }

        public async Task<HomeViewModel> LoadHome()
        {
            var model = new HomeViewModel();

            model.Categories = await this._categoryService.GetCategoryViewModels();
            model.Listings = await this._listingService.GetListingViewModels();
            return model;
        }
    }
}
