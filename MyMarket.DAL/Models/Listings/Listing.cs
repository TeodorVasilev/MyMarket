using MyMarket.DAL.Models.Account;
using MyMarket.DAL.Models.Images;

namespace MyMarket.DAL.Models.Listings
{
    public class Listing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool PriceNegotiable { get; set; }
        public bool PrivateSale { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
