namespace MyMarket.DAL.Models.Listings
{
    public class StaticOption
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
