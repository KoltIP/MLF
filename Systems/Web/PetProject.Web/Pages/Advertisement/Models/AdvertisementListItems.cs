namespace PetProject.Web.Pages.Advertisement.Models
{
    public class AdvertisementListItems
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public string PetColor { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
    }
}
