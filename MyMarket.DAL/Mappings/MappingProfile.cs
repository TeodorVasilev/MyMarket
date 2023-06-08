using AutoMapper;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.ViewModels.Listings;

namespace MyMarket.DAL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ListingOption, OptionViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Option.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Option.Value))
                .ForMember(dest => dest.PropertyId, opt => opt.MapFrom(src => src.Option.PropertyId))
                .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.Option.Property.Name));
            CreateMap<Listing, DisplayListingViewModel>()
                .ForMember(dest => dest.ImagePaths, opt => opt.MapFrom(src => src.Images.Select(i => i.ImagePath).ToList()))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.ListingOptions));
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Property, PropertyViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.CategoryProperties.Select(cp => cp.Category)))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.StaticOptions));
            CreateMap<StaticOption, StaticOptionViewModel>()
                .ForMember(dest => dest.Property, opt => opt.MapFrom(src => src.Property.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Value));
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


