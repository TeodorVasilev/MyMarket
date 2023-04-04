using AutoMapper;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.DAL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }

        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}


