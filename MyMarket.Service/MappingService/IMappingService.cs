namespace MyMarket.Service.MappingService
{
    public interface IMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
