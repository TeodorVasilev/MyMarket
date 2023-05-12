using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.DAL.ViewModels.Search;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMappingService _mappingService;
        public SearchService(ApplicationDbContext context, IMappingService mappingService)
        {
            this._context = context;
            this._mappingService = mappingService;  
        }

        public async Task<object> Search(SearchViewModel formData)
        {
            switch (formData.Type.ToLower())
            {
                case "categories":
                    var categories = await this._context.Categories
                        .Where(c => c.Name.Contains(formData.Term))
                        .ToListAsync();
                    return this._mappingService.Map<List<Category>, List<CategoryViewModel>>(categories);
                case "properties":
                    var properties = await this._context.Properties
                        .Where(p => p.Name.Contains(formData.Term))
                        .ToListAsync();
                    return this._mappingService.Map<List<Property>, List<PropertyViewModel>>(properties);
                default:
                    return null;
            }
        }
    }
}
