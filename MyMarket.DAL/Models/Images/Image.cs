using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Models.Images
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] BinaryData { get; set; }
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
