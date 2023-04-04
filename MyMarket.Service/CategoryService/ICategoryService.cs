using MyMarket.DAL.Models.Listings;

namespace MyMarket.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
    }
}
