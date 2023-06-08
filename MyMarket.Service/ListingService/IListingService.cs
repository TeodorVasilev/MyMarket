using Microsoft.AspNetCore.Http;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.Service.ListingService
{
    public interface IListingService
    {
        Task<List<DisplayListingViewModel>> GetListingsByCategoryId(int categoryId);
        Task<List<DisplayListingViewModel>> GetListingViewModels();
        Task<DisplayListingViewModel> GetListingViewModel(int id);
        Task<List<string>> SaveImages(IFormFileCollection images);
        Task<List<Listing>> GetListings();
        Task<Listing> GetListing(int id);
        Task Create(CreateListingViewModel formData);
        Task Delete(int id);
    }
}
