namespace MyMarket.DAL.ViewModels.Listings
{
    public class StaticOptionViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int PropertyId { get; set; }
        public string Property { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
