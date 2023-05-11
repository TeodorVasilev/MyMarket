using Microsoft.AspNetCore.Mvc;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.DAL.ViewModels.Search;
using MyMarket.Service.SearchService;

namespace MyMarket.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }
        public async Task<IActionResult> Search(SearchViewModel formData)
        {
            var searchResults = await this._searchService.Search(formData);

            switch (formData.Type)
            {
                case "categories":
                    var categories = searchResults as List<CategoryViewModel>;
                    return Ok(categories);
                    break;
                default:
                    throw new ArgumentException("Invalid search type", nameof(formData.Type));
            }
            //
            return RedirectToAction("Categories", "Category");
        }
    }
}
