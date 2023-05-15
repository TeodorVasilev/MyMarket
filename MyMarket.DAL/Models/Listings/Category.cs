namespace MyMarket.DAL.Models.Listings
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<CategoryProperty> CategoryProperties { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
