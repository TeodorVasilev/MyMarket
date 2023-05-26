namespace MyMarket.DAL.ViewModels.Listings
{
    public class DisplayListingViewModel
    {
        public DisplayListingViewModel()
        {
            this.Options = new List<OptionViewModel>();
            this.ImagePaths = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool PriceNegotiable { get; set; }
        public bool PrivateSale { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public ICollection<OptionViewModel> Options { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}
