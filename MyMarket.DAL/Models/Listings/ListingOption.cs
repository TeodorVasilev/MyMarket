namespace MyMarket.DAL.Models.Listings
{
    public class ListingOption
    {
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
    }
}
