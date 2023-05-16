using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.OptionService
{
    public class OptionService : IOptionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMappingService _mappingService;
        public OptionService(ApplicationDbContext context, IMappingService mappingService)
        {
            this._context = context;
            this._mappingService = mappingService;
        }

        public async Task Create(StaticOptionViewModel formData)
        {
            var option = new StaticOption()
            {
                Value = formData.Value,
                PropertyId = formData.PropertyId,
            };
            
            await _context.StaticOptions.AddAsync(option);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var option = await this.GetOptionById(id);
            this._context.StaticOptions.Remove(option);
            await this._context.SaveChangesAsync();
        }

        public async Task<StaticOption> GetOptionById(int id)
        {
            return await this._context.StaticOptions.Where(so => so.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<StaticOption>> GetOptions()
        {
            return await this._context.StaticOptions.ToListAsync();
        }

        public async Task<StaticOptionViewModel> GetOptionViewModel(int id)
        {
            var option = await this.GetOptionById(id);
            return this._mappingService.Map<StaticOption, StaticOptionViewModel>(option);
        }

        public async Task<List<StaticOptionViewModel>> GetOptionViewModels()
        {
            var options = await this.GetOptions();
            return this._mappingService.Map <List<StaticOption>, List<StaticOptionViewModel>>(options);
        }

        public async Task Update(StaticOptionViewModel formData)
        {
            throw new NotImplementedException();
        }
    }
}
