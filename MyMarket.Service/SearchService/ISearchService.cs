using MyMarket.DAL.ViewModels.Search;

namespace MyMarket.Service.SearchService
{
    public interface ISearchService
    {
        Task<object> Search(SearchViewModel formData);
    }
}
