using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Images;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;
using MyMarket.Service.MappingService;

namespace MyMarket.Service.ListingService
{
    public class ListingService : IListingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMappingService _mappingService;

        public ListingService(ApplicationDbContext context, IMappingService mappingService)
        {
            this._context = context;
            this._mappingService = mappingService;
        }

        public async Task<List<Listing>> GetListings()
        {
            return await this._context.Listings.Include(l => l.Options).Include(l => l.Images).ToListAsync();
        }

        public async Task Create(CreateListingViewModel formData)
        {
            var listing = new Listing()
            {
                UserId = formData.UserId,
                CategoryId = formData.CategoryId,
                Name = formData.Name,
                Description = formData.Description,
                Price = formData.Price,
                Address = formData.Address,
                Phone = formData.Phone,
                PriceNegotiable = formData.PriceNegotiable,
                PrivateSale = formData.PrivateSale,
                ListingOptions = new List<ListingOption>(),
            };

            this._context.Listings.Add(listing);

            foreach (var opt in formData.Options)
            {
                var option = new Option
                {
                    PropertyId = opt.PropertyId,
                    Value = opt.Value,
                };

                this._context.Options.Add(option);

                var listingOption = new ListingOption()
                {
                    Listing = listing,
                    Option = option
                };
                listing.ListingOptions.Add(listingOption);
            }

            var imagePaths = await SaveImages(formData.Images);

            foreach (var path in imagePaths)
            {
                var image = new Image
                {
                    ImagePath = path,
                    Listing = listing
                };

                this._context.Images.Add(image);
            }

            await this._context.SaveChangesAsync();
        }

        public async Task<List<string>> SaveImages(IFormFileCollection images)
        {
            var imagePaths = new List<string>();

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            foreach (var image in images)
            {
                var filePath = Path.Combine(uploadPath, image.FileName);

                Directory.CreateDirectory(uploadPath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                var relativePath = Path.Combine("uploads", image.FileName);
                imagePaths.Add(relativePath);
            }

            return imagePaths;
        }

        public async Task<List<DisplayListingViewModel>> GetListingViewModels()
        {
            var listings = await this.GetListings();
            return this._mappingService.Map<List<Listing>, List<DisplayListingViewModel>>(listings);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DisplayListingViewModel> GetListingViewModel(int id)
        {
            var listing = await this.GetListing(id);
            return this._mappingService.Map<Listing, DisplayListingViewModel>(listing);
        }

        public async Task<List<DisplayListingViewModel>> GetListingsByCategoryId(int categoryId)
        {
            var childCategoryIds = await this._context.Categories
                .Where(c => c.ParentId == categoryId)
                .Select(c => c.Id)
                .ToListAsync();

            childCategoryIds.Add(categoryId);

            var listings = await this._context.Listings
                .Where(l => childCategoryIds.Contains(l.CategoryId))
                .Include(l => l.Options)
                .Include(l => l.Images)
                .Include(c => c.Category)
                .ThenInclude(c => c.Parent)
                .ToListAsync();

            return this._mappingService.Map<List<Listing>, List<DisplayListingViewModel>>(listings);
        }

        public async Task<Listing> GetListing(int id)
        {
            return await this._context.Listings.Where(l => l.Id == id).Include(l => l.Images).Include(l => l.ListingOptions)
                .ThenInclude(lo => lo.Option).ThenInclude(o => o.Property).FirstOrDefaultAsync();
        }
    }
}
