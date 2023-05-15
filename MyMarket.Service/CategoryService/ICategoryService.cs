using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
        Task<List<CategoryViewModel>> GetParentCategoriesViewModels();
        Task<List<CategoryViewModel>> GetChildCategoriesViewModels(int parentId);
        Task<List<CategoryViewModel>> GetCategoryViewModels();
        Task<CategoryViewModel> GetCategoryViewModel(int id);
        Task Create(CategoryViewModel formData);
        Task Update(CategoryViewModel formData);
        Task Delete(int id);
    }
}
