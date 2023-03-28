namespace PetProject.Api.Controllers.File.Models
{
    public class FileResponse
    {
        public int Id { get; set; }
        public string ImageDataUrl { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
