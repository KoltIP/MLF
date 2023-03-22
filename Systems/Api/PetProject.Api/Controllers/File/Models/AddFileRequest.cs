namespace PetProject.Api.Controllers.File.Models
{
    public class AddFileRequest
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String ContentType { get; set; }
        public Int64 Size { get; set; }
        public Byte[] Content { get; set; }
        public String ImageDataUrl { get; set; }

        public AddFileRequest()
        {
            Id = Guid.NewGuid();
        }
    }
}
