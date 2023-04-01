using PetProject.Web.Pages.Content.Models.File;

namespace PetProject.Web.Pages.Content.Models.Advertisement
{
    public class AddAdvertisementModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string? PetName { get; set; }
        public string? PetDescription { get; set; }
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetBreedId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
        public DateTime? DateLost { get; set; }
        public FileModel File { get; set; } = new FileModel();
    }
}
