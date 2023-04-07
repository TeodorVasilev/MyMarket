namespace MyMarket.DAL.ViewModels.Listings
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public List<CategoryViewModel> Children { get; set; }
    }
}
