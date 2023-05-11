using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMappingService _mappingService;
        public CategoryService(ApplicationDbContext context, IMappingService mappingService)
        {
            this._context = context;
            this._mappingService = mappingService;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await this._context.Categories.Include(c => c.Children).ThenInclude(ch => ch.Children).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await this._context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CategoryViewModel>> GetCategoryViewModels()
        {
            var categories = await this.GetCategories();
            return this._mappingService.Map<List<Category>, List<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetCategoryViewModel(int id)
        {
            var category = await this.GetCategoryById(id);
            return this._mappingService.Map<Category, CategoryViewModel>(category);
        }

        public async Task Create(CategoryViewModel formData)
        {
            var category = new Category()
            {
                Name = formData.Name,
                ParentId = formData.ParentId,
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CategoryViewModel formData)
        {
            var category = await this.GetCategoryById(formData.Id);

            if(formData.Name != category.Name)
            {
                category.Name = formData.Name;
            }
            if(formData.ParentId != category.ParentId)
            {
                category.ParentId = formData.ParentId;
            }

            await this._context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await this.GetCategoryById(id);
            this._context.Categories.Remove(category);
            await this._context.SaveChangesAsync();
        }
    }
}
