using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.PropertyService
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMappingService _mappingService;
        public PropertyService(ApplicationDbContext context, IMappingService mappingService)
        {
            this._context = context;
            this._mappingService = mappingService;
        }

        public async Task Create(PropertyViewModel formData)
        {
            var property = new Property()
            {
                Name = formData.Name,
            };

            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var property = await this.GetPropertyById(id);
            this._context.Properties.Remove(property);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<Property>> GetProperties()
        {
            return await this._context.Properties.ToListAsync();
        }

        public async Task<Property> GetPropertyById(int id)
        {
            return await this._context.Properties.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PropertyViewModel> GetPropertyViewModel(int id)
        {
            var property = await this.GetPropertyById(id);
            return this._mappingService.Map<Property, PropertyViewModel>(property);
        }

        public async Task<List<PropertyViewModel>> GetPropertyViewModels()
        {
            var properties = await this.GetProperties();
            return this._mappingService.Map<List<Property>, List<PropertyViewModel>>(properties);
        }

        public async Task Update(PropertyViewModel formData)
        {
            var property = await this.GetPropertyById(formData.Id);

            if (formData.Name != property.Name)
            {
                property.Name = formData.Name;
            }

            await this._context.SaveChangesAsync();
        }
    }
}
