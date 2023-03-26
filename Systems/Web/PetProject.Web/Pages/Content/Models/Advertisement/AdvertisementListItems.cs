namespace PetProject.Web.Pages.Advertisement.Models.Advertisement
{
    public class AdvertisementListItems
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public string PetColor { get; set; } = string.Empty;
        public int PetBreedId { get; set; }
        public string PetBreed { get; set; } = string.Empty;
        public int PetTypeId { get; set; }
        public string PetType { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string City { get; set; } = string.Empty;
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
    }
}
