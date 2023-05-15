namespace MyMarket.DAL.Models.Listings
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<PropertyOption> PropertyOptions { get; set; }
        public virtual ICollection<CategoryProperty> CategoryProperties { get; set; }
    }
}
