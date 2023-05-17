namespace MyMarket.DAL.ViewModels.Listings
{
    public class PropertyViewModel
    {
        public PropertyViewModel()
        {
            this.CategoriesIds = new List<int>();
            this.Categories = new List<CategoryViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> CategoriesIds { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
