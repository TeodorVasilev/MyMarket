using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
        Task<List<CategoryViewModel>> GetCategoryViewModels();
    }
}
