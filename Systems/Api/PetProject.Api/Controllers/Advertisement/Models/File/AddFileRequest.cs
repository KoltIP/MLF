namespace PetProject.Api.Controllers.Advertisement.Models.File
{
    public class AddFileRequest
    {
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
