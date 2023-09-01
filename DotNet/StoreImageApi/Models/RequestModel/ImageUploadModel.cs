namespace StoreImageApi.Models.RequestModel
{
    public class ImageUploadModel
    {
        public IFormFile ImageFile { get; set; }  // This property will hold the base64-encoded image data
    }
}
