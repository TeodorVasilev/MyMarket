using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.Service.OptionService
{
    public interface IOptionService
    {
        Task<StaticOption> GetOptionById(int id);
        Task<List<StaticOption>> GetOptions();
        Task<List<StaticOptionViewModel>> GetOptionViewModels();
        Task<StaticOptionViewModel> GetOptionViewModel(int id);
        Task Create(StaticOptionViewModel formData);
        Task Update(StaticOptionViewModel formData);
        Task Delete(int id);
    }
}
