using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await this._context.Categories.Include(c => c.Children).ThenInclude(ch => ch.Children).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await this._context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
