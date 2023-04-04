using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.DAL.ViewModels.Pages.Home;
using MyMarket.Service.CategoryService;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.PageService.Home
{
    public class HomeService : IHomeService
    {
        private readonly IMappingService _mappingService;
        private readonly ICategoryService _categoryService;

        public HomeService(IMappingService mappingService, ICategoryService categoryService)
        {
            this._mappingService = mappingService;
            this._categoryService = categoryService;
        }

        public async Task<HomeViewModel> LoadHome()
        {
            var model = new HomeViewModel();
            var categories = await _categoryService.GetCategories();

            model.Categories = this._mappingService.Map<List<Category>, List<CategoryViewModel>>(categories);

            return model;
        }
    }
}
