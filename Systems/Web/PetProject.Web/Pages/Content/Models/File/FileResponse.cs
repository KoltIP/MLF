namespace PetProject.Web.Pages.Content.Models.File
{
    public class FileResponse
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public String ContentType { get; set; }
        public Byte[] Content { get; set; }
    }
}
