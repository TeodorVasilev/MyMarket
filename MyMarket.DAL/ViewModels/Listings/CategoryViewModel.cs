namespace MyMarket.DAL.ViewModels.Listings
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<CategoryViewModel> Children { get; set; }
    }
}
