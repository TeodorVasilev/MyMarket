namespace MyMarket.DAL.ViewModels.Images
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public byte[] BinaryData { get; set; }
        public int ProductId { get; set; }
    }
}
