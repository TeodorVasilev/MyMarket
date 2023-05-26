namespace MyMarket.DAL.Models.Listings
{
    public class Option
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public virtual Property Property { get; set; }
        public int PropertyId { get; set; }
        public virtual ICollection<ListingOption> ListingOptions { get; set; }
        public virtual ICollection<PropertyOption> PropertyOptions { get; set; }
    }
}
