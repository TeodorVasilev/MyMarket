using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.DAL.ViewModels.Pages.Home;
using MyMarket.Service.CategoryService;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.PageService.Home
{
    public class HomeService : IHomeService
    {
        private readonly ICategoryService _categoryService;

        public HomeService(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public async Task<HomeViewModel> LoadHome()
        {
            var model = new HomeViewModel();

            model.Categories = await this._categoryService.GetCategoryViewModels();

            return model;
        }
    }
}
