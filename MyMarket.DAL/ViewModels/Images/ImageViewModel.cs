using Microsoft.AspNetCore.Http;

namespace MyMarket.DAL.ViewModels.Images
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
        public int ProductId { get; set; }
    }
}
