namespace MyMarket.DAL.Models.Listings
{
    public class PropertyOption
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }
    }
}
