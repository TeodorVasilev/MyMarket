namespace MyMarket.DAL.Models.Listings
{
    public class StaticOption
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Property Property { get; set; }
        public int PropertyId { get; set; }
        public int? ParentId { get; set; }
        public virtual StaticOption? Parent { get; set; }
        public virtual ICollection<StaticOption> Children { get; set; }

    }
}
