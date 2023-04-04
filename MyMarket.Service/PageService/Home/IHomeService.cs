using MyMarket.DAL.ViewModels.Pages.Home;

namespace MyMarket.Service.PageService.Home
{
    public interface IHomeService
    {
        Task<HomeViewModel> LoadHome();
    }
}
