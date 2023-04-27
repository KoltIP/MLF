namespace PetProject.Api.Controllers.File.Models
{
    public class AddFileRequest
    {
        public String ContentType { get; set; }
        public Byte[] Content { get; set; }
    }
}
