namespace MyMarket.DAL.Models.Listings
{
    public class Option
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public Listing Listing { get; set; }
        public int ListingId { get; set; }
    }
}
