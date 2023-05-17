using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.Service.PropertyService
{
    public interface IPropertyService
    {
        Task<Property> GetPropertyById(int id);
        Task<List<Property>> GetProperties();
        Task<List<PropertyViewModel>> GetPropertyViewModels();
        Task<List<PropertyViewModel>> GetPropertiesByCategoryId(int categoryId);
        Task<List<PropertyViewModel>> GetPropertiesWithCategories();
        Task<PropertyViewModel> GetPropertyViewModel(int id);
        Task Create(PropertyViewModel formData);
        Task Update(PropertyViewModel formData);
        Task Delete(int id);
    }
}
